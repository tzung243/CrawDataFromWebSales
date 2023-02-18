﻿using Nest;
using System.Collections.Generic;
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

    }
}

