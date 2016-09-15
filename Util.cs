using System.Collections.Generic;
using System.Net;

namespace Qrawd_web.Class {
    public class Util {
        // paralel download method untuk melakukan download beberapa file secara bersamaan
        public static void ParalelDownload(List<DownloadModel> listModel) {
            var handler = new System.Net.Http.HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate, UseProxy = false };
            var client = new System.Net.Http.HttpClient(handler);
            if (Xamarin.Forms.Device.OS == Xamarin.Forms.TargetPlatform.iOS) {
                client.DefaultRequestHeaders.TryAddWithoutValidation("AcceptEncoding", "gzip, deflate");
                client.DefaultRequestHeaders.TryAddWithoutValidation("UserAgent", "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_10_5) AppleWebKit/601.5.17 (KHTML, like Gecko) Version/9.1 Safari/601.5.17");
                client.DefaultRequestHeaders.TryAddWithoutValidation("AcceptCharset", "utf-8;q=0.7,*;q=0.7");
            } else {
                client.DefaultRequestHeaders.TryAddWithoutValidation("AcceptEncoding", "gzip, deflate");
                client.DefaultRequestHeaders.TryAddWithoutValidation("UserAgent", "Mozilla/5.0 (Windows; U; Windows NT 6.1; ru; rv:48.0) Gecko/20100101 Firefox/48.0");
                client.DefaultRequestHeaders.TryAddWithoutValidation("AcceptCharset", "windows-1251,utf-8;q=0.7,*;q=0.7");
            }

            // start download
            var res = System.Threading.Tasks.Parallel.ForEach(listModel, async (obj) => {
                if (!string.IsNullOrWhiteSpace(obj.URL) && !string.IsNullOrWhiteSpace(obj.URL)) {
                    var data = await client.GetByteArrayAsync(obj.URL);
                    if (data != null) {
                        System.IO.File.WriteAllBytes(obj.FilePath, data);
                    }
                }
            });

            if (!res.IsCompleted) {
                System.Diagnostics.Debug.Print(Xamarin.Forms.Device.OnPlatform("iOS", "Android", "WinPhone") + " - Some/all file couldn't be downloaded!");
            }
        }
    }

    public class DownloadModel {
        public string URL { get; set; }
        public string FilePath { get; set; }
    }
}
