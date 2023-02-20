using Model;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESEngine
{
    public class EService
    {
        public ElasticClient Client { get; }

        public EService()
        {
            Client = new ElasticClient("craw_data:dXMtY2VudHJhbDEuZ2NwLmNsb3VkLmVzLmlvOjQ0MyQ3OGU2Y2Q2OWIwYWQ0NTczYWMwNDNkYThmNDdlZTE0ZiQ4YTM0NTJlMDBlYzU0NzE1YTA1MmQ1MDdjMWRlMDk4NA==",
              new Elasticsearch.Net.ApiKeyAuthenticationCredentials("T3R1c1NJWUJKdUNELWYxb2lhTUM6aWJ5TjNDcmVTYjJpT1BKTFlvUTlFZw=="));

            //var listUrls = new Uri[]
            //  {
            //    new Uri("http://localhost:9200/")
            //  };

            //var conPool = new StaticConnectionPool(listUrls);
            //var conSettings = new ConnectionSettings(conPool);

            //conSettings.ThrowExceptions();
            //conSettings.PrettyJson();
            //conSettings.RequestTimeout(TimeSpan.FromMinutes(2));
            //this.Client = new ElasticClient(conSettings);

            //Client.Indices.Create("product", c => c.Map<Product>(m => m.AutoMap()));
            //Client.Indices.Create("link", c => c.Map<Data>(m => m.AutoMap()));

        }

        public async Task<long> countIndex(string index)
        {
            CountRequest countReq = new CountRequest(index);
            var resp = await Client.CountAsync(countReq);

            return resp.Count;
        }

        public async Task indexDatasAsync(IEnumerable<Data> list)
        {
            var response = await Client.IndexManyAsync(list, "test");

        }

        public async Task<ISearchResponse<Data>> SearchDataFrom(int from)
        {
            var response = await Client.SearchAsync<Data>(s => s
                                        .Index("test")
                                        .Query(q => q
                                            .MatchAll()
                                            )
                                        .Sort((sd) =>
                                        {
                                            sd.Descending(new Field("time_load"));
                                            return sd;
                                        })
                                        .From(from)
                                        .Size(20)
                                        );
            return response;
        }

        public void createData(Data data)
        {
            Client.Index<Data>(data, s => s.Index("test"));
        }
        public void updateData(Data data)
        {
            var response = Client.Update<Data, object>(data._id, (ud) =>
            {

                ud.Doc(new Data
                {
                    url = data.url,
                    name = data.name,
                    price = data.price,
                    description = data.description,
                    time_load = data.time_load,
                    status = data.status,
                    is_belonged = data.is_belonged,
                    product_id = data.product_id
                }).Index("test");
                return ud;
            });
        }

        public List<Data> getLinksProduct(string nameProduct, int status, string domain, double price_from, double price_to, DateTime? update_from, DateTime? update_to, DateTime? create_from, DateTime? create_to, bool isBelonged)
        {
            var resp = Client.Search<Data>((searchReq) =>
            {
                searchReq.Index("test").From(0).Size(1000);

                searchReq.Query((queryReq) =>
                {
                    queryReq.Bool((boolReq) =>
                    {
                        var _boolReq = boolReq;
                        _boolReq = boolReq.Must((queries) =>
                        {
                            dynamic _queries = queries;
                            if (nameProduct != string.Empty)
                                _queries = _queries && queries.Match((matchNameReq) => matchNameReq.Field(fields => fields.name).Query(nameProduct));
                            if (domain != string.Empty)
                                _queries = _queries && queries.Term((termReq) => termReq.domain, domain);
                            if (price_from != -1 && price_to != -1)
                                _queries = _queries && queries.Range(r => r.Field(f => f.price)
                                       .GreaterThanOrEquals(price_from)
                                                .LessThanOrEquals(price_to));
                            return _queries;
                        });
                        _boolReq = _boolReq.Filter(filter =>
                        {
                            dynamic _filter = filter;
                            if (status != -1)
                                _filter = _filter && filter.Term((termReq) => termReq.status, status);


                            if (update_from != null && update_from != null)
                                _filter = _filter && filter.DateRange(d => d.Field(fie => fie.time_update)
                                                            .GreaterThanOrEquals(update_from)
                                                            .LessThanOrEquals(update_to));
                            if (create_from != null && create_from != null)
                                _filter = _filter && filter.DateRange(d => d.Field(fie => fie.time_create)
                                                                                            .GreaterThanOrEquals(create_from)
                                                                                            .LessThanOrEquals(create_to));
                            if (isBelonged)
                                _filter = _filter && filter.Term(t => t.is_belonged, isBelonged);

                            return _filter;
                        });
                        return _boolReq;
                    });
                    return queryReq;
                });
                return searchReq;
            });
            return resp.Documents.ToList();
        }

        public List<Product> getProduct(string nameProduct, double price_from, double price_to, DateTime? create_from, DateTime? create_to, int numberlinksFrom, int numberlinksTo)
        {
            var resp = Client.Search<Product>((searchReq) =>
            {
                searchReq.Index("product").From(0).Size(1000);

                searchReq.Query((queryReq) =>
                {
                    queryReq.Bool((boolReq) =>
                    {
                        var _boolReq = boolReq;
                        _boolReq = boolReq.Must((queries) =>
                        {
                            dynamic _queries = queries;
                            if (nameProduct != string.Empty)
                                _queries = _queries && queries.Match((matchNameReq) => matchNameReq.Field(fields => fields.name).Query(nameProduct));


                            if (price_from != -1 && price_to != -1)
                                _queries = _queries && queries.Range(r => r.Field(f => f.price)
                                       .GreaterThanOrEquals(price_from)
                                                .LessThanOrEquals(price_to));

                            if (numberlinksFrom != -1 && numberlinksTo != -1)
                                _queries = _queries && queries.Range(r => r.Field(f => f.totalLinks)
                            .GreaterThanOrEquals(numberlinksFrom)
                            .LessThanOrEquals(numberlinksTo));
                            return _queries;
                        });

                        _boolReq = _boolReq.Filter(filter =>
                        {
                            dynamic _filter = filter;
                            if (create_from != null && create_from != null)
                                _filter = _filter && filter.DateRange(d => d.Field(fie => fie.created)
                                                                                            .GreaterThanOrEquals(create_from)
                                                                                            .LessThanOrEquals(create_to));


                            return _filter;
                        });
                        return _boolReq;
                    });
                    return queryReq;
                });
                return searchReq;
            });
            return resp.Documents.ToList();

        }

        public List<Data> getOldestCrawledLinks(int size)
        {
            var resp = Client.Search<Data>(s => s.Size(size)
                                                            .Index("test")
                                                            .Sort(sort => sort
                                                                    .Script(sd => sd
                                                                           .Type("number")
                                                                           .Script(sdd => sdd
                                                                                  .Source("if(doc['status'].value == 0) { return 0;}" +
                                                                                           "if(doc['status'].value == 2) {return 1;} return 2;"))
                                                                           .Ascending())
                                                                    .Descending(desc => desc.time_load)));
            return resp.Documents.ToList();
        }



        public List<StatisProducts> statisDomain()
        {
            var query = Client.Search<Data>(q => q
              .Index("data-index")
              .Size(0)
              .Aggregations(agg => agg.Terms("my-statis", e => e.Field("domain.keyword"))
              )
          );
            try
            {
                var results = query.Aggregations
                .Terms("my-statis")
                .Buckets
                .Select(e => new StatisProducts
                {
                    Key = e.Key,
                    count = (long)e.DocCount
                });
                return results.ToList();
            }
            catch (Exception)
            {
                return null;
            }

        }

        public List<StatisProducts> statisStatus()
        {
            var query = Client.Search<Data>(q => q
              .Index("data-index")
              .Size(0)
              .Aggregations(agg => agg.Terms("my-statis", e => e.Field("status"))
              )
          );
            try
            {
                var results = query.Aggregations
                .Terms("my-statis")
                .Buckets
                .Select(e => new StatisProducts
                {
                    Key = e.Key,
                    count = (long)e.DocCount
                });
                return results.ToList();
            }
            catch (Exception)
            {
                return null;
            }

        }

        public bool checkExitsData(string url)
        {
            var resp = Client.Count<Data>(c => c.Index("test")
                                                .Query(q => q.Match(m => m.Field("url.keyword").Query(url))));

            return resp.Count == 1;
        }
        /*
/*
        public async Task<Product> getProductByName(string name)
        {
            var resp = await Client.SearchAsync<Product>(s => s.From(0)
                                                       .Size(10)
                                                       .Index("product")
                                                       .Query(q => q.Match(m => m.Field(f => f.name).Query(name))));
            return resp.Documents.First();
        }

        public async Task<List<Product>> getProductsByPrice(double from, double to)
        {
            var resp = await Client.SearchAsync<Product>(s => s.From(0)
                                                      .Size(10)
                                                      .Index("test")
                                                      .Query(q => q.Range(r => r.Field(f => f.price)
                                                                                        .GreaterThanOrEquals(from)
                                                                                        .LessThanOrEquals(to))));
            return resp.Documents.ToList();
        }

        public async Task<List<Product>> getProductsByCreatedTime(DateTime from, DateTime to)
        {
            var resp = await Client.SearchAsync<Product>(s => s.From(0)
                                                            .Size(10)
                                                            .Index("test")
                                                            .Query(q => q.DateRange(r => r.Field(f => f.created)
                                                                                        .GreaterThanOrEquals(from)
                                                                                        .LessThanOrEquals(to))));
            return resp.Documents.ToList();
        }

        public async Task<List<Product>> getProductsByTotalLinks(int from, int to)
        {
            var resp = await Client.SearchAsync<Product>(s => s.From(0)
                                                            .Size(10)
                                                            .Index("test")
                                                            .Query(q => q.Range(r => r.Field(f => f.totalLinks)
                                                                                        .GreaterThanOrEquals(from)
                                                                                        .LessThanOrEquals(to))));
            return resp.Documents.ToList();
        }
*/
        public async Task createProduct(Product product)
        {
            var resp = await Client.IndexAsync<Product>(product, i => i.Index("product"));

        }

        public async Task updateProduct(Product product)
        {
            var par = new Product
            {
                _id = product._id,
                name = product.name,
                description = product.description,
                price = product.price,
                branch = product.branch,
                model = product.model,
                created = product.created,
                lastUpdated = product.lastUpdated,
                status = product.status,
                totalLinks = product.totalLinks
            };

            await Client.UpdateAsync<Product>(product._id, u => u.Doc(par).Index("product"));
        }

        public async Task deletedProduct(string id)
        {
            await Client.DeleteAsync<Product>(id, d => d.Index("product"));
        }

    }
}
