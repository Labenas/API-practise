using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace API_practise
{
    
    class Program
    {
        static async Task Main(string[] args)
        {
            HttpClient client = new HttpClient();

            //Find Id of user Named Mrs. Dennis Schulist
            var responseUser = await client.GetAsync("https://jsonplaceholder.typicode.com/users");
            var responseUserBody = await responseUser.Content.ReadAsStringAsync();
            var responeObjectUser = JsonConvert.DeserializeObject<List<User>>(responseUserBody);
            
            var filteredResultUser = responeObjectUser.Where(r => r.name == "Mrs. Dennis Schulist").Select(r => r.id);

            foreach (var item in filteredResultUser)
            {
                Console.WriteLine($"User Mrs. Dennis Schulist id is {item}");
               
            }

            //Finding Albums 
            var responseAlbum = await client.GetAsync("https://jsonplaceholder.typicode.com/albums");
            var responseAlbumBody = await responseAlbum.Content.ReadAsStringAsync();
            var responseObjectAlbum = JsonConvert.DeserializeObject<List<Album>>(responseAlbumBody);

            var filteredResultAlbum = responseObjectAlbum.Where(r => r.userId == 6 ).Select(r => r.id).ToArray();

            // Finding Photos
            var responsePhoto = await client.GetAsync("https://jsonplaceholder.typicode.com/photos");
            var responsePhotoBody = await responsePhoto.Content.ReadAsStringAsync();
            var responseObjectPhoto = JsonConvert.DeserializeObject<List<Photo>>(responsePhotoBody);
            


            foreach (var album in filteredResultAlbum)
            {
                Console.WriteLine($"\nMrs. Dennis Schulist got album Nr. { album}\n");

                var filteredResultPhoto = responseObjectPhoto.Where(r => r.albumId == album).Select(r => r.url).ToArray();

                foreach (var photo in filteredResultPhoto)
                {
                    Console.WriteLine(photo);
                }

            }

           

        }
    }
}
