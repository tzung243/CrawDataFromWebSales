using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrawDataFromWebSales
{
    public class EServicce
    {
        public ElasticClient Client { get; }

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
                    status = data.status
                }).Index("test");
                return ud;
            });
        }


        public async Task<List<Data>> getLinks(string nameProduct, int status, string domain, double priceFrom, double priceTo,
                                        DateTime updatedFrom, DateTime updatedTo, DateTime createdFrom, DateTime createdTo, bool isBelonged)
        {
            var resp = await Client.SearchAsync<Data>(s => s.From(0)
                                                       .Size(10)
                                                       .Index("test")
                                                       .Query(q => q.Bool(b => b.Must(m => m.Term(t => t.name, nameProduct)
                                                                                            && m.Term(t => t.domain, domain)
                                                                                            && m.Range(r => r.Field(f => f.price)
                                                                                                              .GreaterThanOrEquals(priceFrom)
                                                                                                              .LessThanOrEquals(priceTo)))
                                                                                .Filter(f => f.Term(t => t.status, status))
                                                                                .Filter(f => f.DateRange(d => d.Field(fie => fie.time_update)
                                                                                                                .GreaterThanOrEquals(updatedFrom.Date)
                                                                                                                .LessThanOrEquals(updatedTo.AddDays(1).AddSeconds(-1))))
                                                                                .Filter(f => f.DateRange(d => d.Field(fie => fie.time_create)
                                                                                                                .GreaterThanOrEquals(createdFrom.Date)
                                                                                                                .LessThanOrEquals(createdTo.AddDays(1).AddSeconds(-1))))
                                                                                .Filter(f => f.Term(t => t.isBelonged, isBelonged))
                                                                           )));
            return resp.Documents.ToList();
        }

        public async Task<List<Product>> getProducts(string name, double priceFrom, double priceTo, DateTime createdFrom, DateTime createdTo, int totalLinksFrom, int totalLinksTo)
        {
            var resp = await Client.SearchAsync<Product>(s => s.From(0)
                                                       .Size(10)
                                                       .Index("product")
                                                       .Query(q => q.Bool(b => b.Must(m => m.Term(t => t.Name, name)
                                                                                            && m.Range(r => r.Field(f => f.Price)
                                                                                                              .GreaterThanOrEquals(priceFrom)
                                                                                                              .LessThanOrEquals(priceTo))
                                                                                            && m.Range(r => r.Field(fie => fie.TotalLinks)
                                                                                                             .GreaterThanOrEquals(totalLinksFrom)
                                                                                                             .LessThanOrEquals(totalLinksTo)))
                                                                                .Filter(f => f.DateRange(d => d.Field(fie => fie.Created)
                                                                                                                .GreaterThanOrEquals(createdFrom.Date)
                                                                                                                .LessThanOrEquals(createdTo.AddDays(1).AddSeconds(-1))))
                                                                           )));
            return resp.Documents.ToList();
        }


    }
}

