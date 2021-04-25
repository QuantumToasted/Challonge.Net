﻿using Challonge.Attachments;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net.Http;

namespace Challonge
{
    public partial class ChallongeClient
    {
        public class AttachmentsHandler
        {
            private readonly string apiKey;
            private readonly HttpClient httpClient;

            public AttachmentsHandler(string apiKey, HttpClient httpClient)
            {
                this.apiKey = apiKey;
                this.httpClient = httpClient;
            }

            /// <summary>
            /// Retrieve a match's attachments.
            /// </summary>
            /// <returns></returns>
            public async Task<Attachment[]> GetAttachmentsAsync(string tournament, int matchId)
            {
                string request = $" https://api.challonge.com/v1/tournaments/{tournament}/matches/{matchId}/attachments.json?api_key={apiKey}";

                HttpResponseMessage response = await httpClient.GetAsync(request);
                string responseString = await ErrorHandler.ParseResponseAsync(response);

                AttachmentData[] attachmentDatas = JsonSerializer.Deserialize<AttachmentData[]>(responseString);
                Attachment[] result = new Attachment[attachmentDatas.Length];

                for (int i = 0; i < attachmentDatas.Length; i++)
                    result[i] = attachmentDatas[i].Attachment;

                return result;
            }

            //TODO add file upload
            public async Task<Attachment> CreateAttachmentAsync(string tournament, int matchId, 
                string file = null, string url = null, string description = null)
            {
                string request = $"https://api.challonge.com/v1/tournaments/{tournament}/matches/{matchId}/attachments.json";

                if (file == null && url == null && description == null)
                    throw new ArgumentNullException("At least 1 of the 3 optional parameters must be provided.");

                Dictionary<string, string> parameters = new Dictionary<string, string>
                {
                    ["api_key"] = apiKey
                };

                if (file != null)
                    parameters["match_attachment[asset]"] = file;

                if (url != null)
                    parameters["match_attachment[url]"] = url;

                if (description != null)
                    parameters["match_attachment[description]"] = description;

                FormUrlEncodedContent content = new FormUrlEncodedContent(parameters);
                HttpResponseMessage response = await httpClient.PostAsync(request, content);

                string responseString = await ErrorHandler.ParseResponseAsync(response);

                AttachmentData attachmentData = JsonSerializer.Deserialize<AttachmentData>(responseString);
                return attachmentData.Attachment;
            }

            public async Task<Attachment> GetAttachmentAsync(string tournament, int matchId, int attachmentId)
            {
                string request = $" https://api.challonge.com/v1/tournaments/{tournament}/matches/{matchId}/attachments/{attachmentId}.?api_key={apiKey}";

                HttpResponseMessage response = await httpClient.GetAsync(request);
                string responseString = await ErrorHandler.ParseResponseAsync(response);

                AttachmentData attachmentData = JsonSerializer.Deserialize<AttachmentData>(responseString);
                return attachmentData.Attachment;
            }

            //TODO add file upload
            public async Task<Attachment> UpdateAttachmentAsync(string tournament, int matchId, int attachmentId,
                string file = null, string url = null, string description = null)
            {
                string request = $"https://api.challonge.com/v1/tournaments/{tournament}/matches/{matchId}/attachments/{attachmentId}.json";

                if (file == null && url == null && description == null)
                    throw new ArgumentNullException("At least 1 of the 3 optional parameters must be provided.");

                Dictionary<string, string> parameters = new Dictionary<string, string>
                {
                    ["api_key"] = apiKey
                };

                if (file != null)
                    parameters["match_attachment[asset]"] = file;

                if (url != null)
                    parameters["match_attachment[url]"] = url;

                if (description != null)
                    parameters["match_attachment[description]"] = description;

                FormUrlEncodedContent content = new FormUrlEncodedContent(parameters);
                HttpResponseMessage response = await httpClient.PutAsync(request, content);

                string responseString = await ErrorHandler.ParseResponseAsync(response);

                AttachmentData attachmentData = JsonSerializer.Deserialize<AttachmentData>(responseString);
                return attachmentData.Attachment;
            }

            public async Task DeleteAttachmentAsync(string tournament, int matchId, int attachmentId)
            {
                string request = $"https://api.challonge.com/v1/tournaments/{tournament}/matches/{matchId}/attachments/{attachmentId}.json?api_key={apiKey}";

                HttpResponseMessage response = await httpClient.DeleteAsync(request);

                await ErrorHandler.ParseResponseAsync(response);
            }
        }
    }
}