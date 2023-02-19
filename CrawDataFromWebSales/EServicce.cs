using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrawDataFromWebSales
{
    public class EServicce
    {
        private ElasticClient Client { get; }

        public EServicce()
        {
            Client = new ElasticClient("craw_data:dXMtY2VudHJhbDEuZ2NwLmNsb3VkLmVzLmlvOjQ0MyQ3OGU2Y2Q2OWIwYWQ0NTczYWMwNDNkYThmNDdlZTE0ZiQ4YTM0NTJlMDBlYzU0NzE1YTA1MmQ1MDdjMWRlMDk4NA==",
              new Elasticsearch.Net.ApiKeyAuthenticationCredentials("T3R1c1NJWUJKdUNELWYxb2lhTUM6aWJ5TjNDcmVTYjJpT1BKTFlvUTlFZw=="));
        }

        public async Task<long> countIndex(string index)
        {
            CountRequest countReq = new CountRequest(index);
            var resp = await Client.CountAsync(countReq);

            return resp.Count;
        }

        public async Task indexDatasAsync(IEnumerable<Data> list)
        {
            var response = await Client.IndexManyAsync(list, "data-index");

        }

        public async Task<ISearchResponse<Data>> SearchDataFrom(int from)
        {
            var response = await Client.SearchAsync<Data>(s => s
                                        .Index("data-index")
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


        public async Task<List<Data>> getLinksByName(string nameProduct)
        {
            var resp = await Client.SearchAsync<Data>(s => s.From(0)
                                                       .Size(10)
                                                       .Index("test")
                                                       .Query(q => q.Match(m => m.Field(f => f.name).Query(nameProduct))));
            return resp.Documents.ToList();
        }

        public async Task<List<Data>> getLinksByStatus(int status)
        {
            var resp = await Client.SearchAsync<Data>(s => s.From(0)
                                                            .Size(10)
                                                            .Index("test")
                                                            .Query(q => q.Bool(b => b.Filter(f => f.Term(t => t.status, status)))));

            return resp.Documents.ToList();
        }
        public async Task<List<Data>> getLinksByDomain(string domain)
        {
            var resp = await Client.SearchAsync<Data>(s => s.From(0)
                                                            .Size(10)
            .Index("test")
                                                            .Query(q => q.Bool(b => b.Filter(f => f.Term(t => t.domain, domain)))));

            return resp.Documents.ToList();
        }
        public async Task<List<Data>> getLinksByPrice(double from, double to)
        {
            var resp = await Client.SearchAsync<Data>(s => s.From(0)
                                                            .Size(10)
                                                            .Index("test")
                                                            .Query(q => q.Range(r => r.Field(f => f.price)
                                                                                        .GreaterThanOrEquals(from)
                                                                                        .LessThanOrEquals(to))));

            return resp.Documents.ToList();
        }
        public async Task<List<Data>> getLinksByUpdatedTime(DateTime from, DateTime to)
        {
            var resp = await Client.SearchAsync<Data>(s => s.From(0)
                                                            .Size(10)
                                                            .Index("test")
                                                            .Query(q => q.DateRange(r => r.Field(f => f.time_update)
                                                                                        .GreaterThanOrEquals(from)
                                                                                        .LessThanOrEquals(to))));

            return resp.Documents.ToList();
        }
        public async Task<List<Data>> getLinksByCreatedTime(DateTime from, DateTime to)
        {
            var resp = await Client.SearchAsync<Data>(s => s.From(0)
                                                            .Size(10)
                                                            .Index("test")
                                                            .Query(q => q.DateRange(r => r.Field(f => f.time_create)
                                                                                        .GreaterThanOrEquals(from)
                                                                                        .LessThanOrEquals(to))));
            return resp.Documents.ToList();
        }

        public async Task<List<Data>> getLinksByBelonged(bool isBelonged)
        {
            var resp = await Client.SearchAsync<Data>(s => s.From(0)
                                                            .Size(10)
                                                            .Index("test")
                                                            .Query(q => q.Bool(b => b.Filter(f => f.Term(t => t.is_belonged, isBelonged)))));
            return resp.Documents.ToList();
        }

        public async Task<Product> getProductByName(string name)
        {
            var resp = await Client.SearchAsync<Product>(s => s.From(0)
                                                       .Size(10)
                                                       .Index("product")
                                                       .Query(q => q.Match(m => m.Field(f => f.Name).Query(name))));
            return resp.Documents.First();
        }

        public async Task<List<Product>> getProductsByPrice(double from, double to)
        {
            var resp = await Client.SearchAsync<Product>(s => s.From(0)
                                                      .Size(10)
                                                      .Index("test")
                                                      .Query(q => q.Range(r => r.Field(f => f.Price)
                                                                                        .GreaterThanOrEquals(from)
                                                                                        .LessThanOrEquals(to))));
            return resp.Documents.ToList();
        }

        public async Task<List<Product>> getProductsByCreatedTime(DateTime from, DateTime to)
        {
            var resp = await Client.SearchAsync<Product>(s => s.From(0)
                                                            .Size(10)
                                                            .Index("test")
                                                            .Query(q => q.DateRange(r => r.Field(f => f.Created)
                                                                                        .GreaterThanOrEquals(from)
                                                                                        .LessThanOrEquals(to))));
            return resp.Documents.ToList();
        }

        public async Task<List<Product>> getProductsByTotalLinks(int from, int to)
        {
            var resp = await Client.SearchAsync<Product>(s => s.From(0)
                                                            .Size(10)
                                                            .Index("test")
                                                            .Query(q => q.Range(r => r.Field(f => f.TotalLinks)
                                                                                        .GreaterThanOrEquals(from)
                                                                                        .LessThanOrEquals(to))));
            return resp.Documents.ToList();
        }

        public async Task createProduct(Product product)
        {
            var resp = await Client.IndexAsync<Product>(product, i => i.Index("product"));

        }

        public async Task updateProduct(Product product)
        {
            var par = new Product
            {
                _id = product._id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Branch = product.Branch,
                Model = product.Model,
                Created = product.Created,
                LastUpdated = product.LastUpdated,
                Status = product.Status,
                TotalLinks = product.TotalLinks
            };

            await Client.UpdateAsync<Product>(product._id, u => u.Doc(par).Index("product"));
        }

        public async Task deletedProduct(string id)
        {
            await Client.DeleteAsync<Product>(id, d => d.Index("product"));
        }

    }
}

