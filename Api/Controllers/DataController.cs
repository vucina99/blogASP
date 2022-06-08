using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess;
using Domen;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly Context _context;

        public DataController(Context context)
        {
            _context = context;
        }

        // POST: api/Default
        [HttpPost]
        public IActionResult Post()
        {

            var post = new List<Post>
            {
                new Post
                {
                    Title="What to Wear in Santorini, Greece",
                    Text="Here’s my Santorini, Greece outfit inspiration! Sundresses + Mix and Match Outfits - Sundresses are a staple for me when traveling around Greece! From short flouncy ones to long ones, I love how effortless they are and that you can pair them with sandals, or, if you’re going out for dinner you could dress them up a bit. Bringing along a few pieces that you can mix and match or dress up — especially for romantic dinners — is super helpful! Shorts + Tops - A number of days involved us hanging out by the pool or adventuring around the island. Casual shorts and tops that you can throw on while still looking cute are a definite must! Bikinis + Swimwear - As some of the days are spent pretty much at the pool — cute swimwear is a must! While the floral suits I’m wearing above have since sold out. Hats + Sandals - While hats aren’t the easiest thing to travel with, I always make a point to bring them as they can really change up an outfit and are great for blocking out some of the harsh rays!",
                    Image="santorini.jpg"
                },
                new Post{
                    Title="Places to Visit in Australia (That Aren’t Sydney)",
                    Text="If you’re looking to experience the natural beauty of Australia and want to see the rainforests and wildlife up close, Daintree, Queensland is your best bet! You can go snorkeling or scuba diving near the famous Great Barrier Reef. - For a truly unique place to stay, consider the Daintree Ecolodge. Instead of a standard room, you can stay in one of the 15 treehouses located throughout the property. It’s located in the heart of the Daintree Rainforest and is a great place to disconnect and enjoy the lush green environment. You can have dinner on the balcony of the Julaymba Restaurant, overlooking a little lagoon. Definitely making a booking to try their Degustation Menu, which highlights flavors from the local area and surrounding farms. It’s a true culinary experience!",
                    Image="australia.jpg"
                },
                new Post{
                    Title="Travel Bucket List for 2021",
                    Text="Go On a Solo Trip - If you’ve never been on a solo trip before, make this your year. It doesn’t matter where you go, just go further than you’ve ever been on your own before. Learning to simply enjoy your own company is truly one of the best things you can do for yourself. And, that doesn’t have to mean crossing the globe solo. Do a Staycation in Your City - Whether you do it solo, with your special someone, or with a group of girlfriends, now is the time for us all to appreciate our homes a little bit more. Find a way to see your city from new eyes and remember why you loved it so much to begin with. Go on a Road Trip - While traveling during COVID may feel like an overwhelming task, it is actually incredibly easy when you opt for a road trip. From the safety and comfort of your own ride, you can see so many incredible sights.",
                    Image="bucketList.jpg"
                },
                new Post{
                    Title="The Best Places to Travel in the United States Right Now",
                    Text="California - As my home state, California is near and dear to my heart, and, in my opinion, one of the best places to road trip! From road tripping the California coast to visiting some iconic national parks, California has a ton to offer. Oregon - With rugged coastlines and vast forests, Oregon is the ideal place to climb that mountain and get your fill of waterfalls. If you love camping, there are so many campgrounds to choose from—just make sure to book ahead. Maine - There’s a common theme on this list of places with rugged, natural beauty…and I’m particularly fond of coastlines. Maine’s rocky shores are a splendid place for isolation and there are tons of places to go hiking, biking, or explore the waterfront. Alaska - There are so many beautiful small towns and tons of history to discover. Being the USA’s largest and most sparsely populated state, you can explore many of the gems like Ketchikan or Juneau, and potentially a glacier or two!",
                    Image="us.jpg"
                },
                new Post{
                    Title="The Ultimate Best Friend Travel Bucket List",
                    Text="Mardi Gras in New Orleans - Mardi Gras aka “Fat Tuesday” is the last day for Catholics to indulge before Lent begins. In New Orleans, this means masked balls, colorful parades, loud music, and beaded necklaces. Hit the Beaches in Mykonos - Greece has become the ultimate hot spot for beach parties, and each year Mykonos beach bar parties get better and better. With tourists touching down every single day, it’s no wonder that world-famous DJs stop by to play. Road Trip Around Iceland - Iceland has popped up on the radar recently and for a good reason. With hiking, geothermal pools, waterfalls, and an iceberg beach, Iceland is a place like no other. Go Scuba Diving - Scuba diving requires a built-in buddy system, so it’s the perfect activity for you and your bestie. There are countless destinations to scuba dive around the world. It’s an underwater world that’s just waiting to be discovered. You can see everything from whales to sea turtles to stingrays to sharks!",
                    Image="bfbusketlist.jpg"
                },
                new Post{
                    Title="The Girl’s Guide to a California Coast Road Trip",
                    Text="Stop 1: Los Angeles - Depending on where you start your road trip, you may want to get through Los Angeles quickly to avoid traffic during rush hours, however, if you want to spend some time in the city, I recommend checking out Santa Monica and Venice Beach! With its manmade canals, strewn about with imported gondolas straight from Italy, Venice Beach evokes a classy yet laid-back vibe. Stop 2: Santa Barbara - Santa Barbara is California’s answer to the Riviera. This is where you’ll find stylish Spanish colonial buildings and upscale boutiques set against the dramatic Santa Ynez Mountains. Be sure to stop by Seven Bar & Kitchen, a tasty roadside bar. Early plates include succulent buttermilk fried chicken, house waffles, fresh egg scrambles, and sausage gravy-stuffed biscuits. Stop 3: Solvang - Solvang was settled by Danish farmers, and all of downtown has a sort of faux-Danish vibe—this means lots of cute bakeries and gift shops! Be sure to stop by Mortensen’s Danish Bakery for the freshest pastries and cookies around. Stop 4: Pismo Beach - Next, drive down to Pismo Beach, self-dubbed “Clam Capital of the World” because of the Pismo clams, which once were abundant here. You’ll find the heritage of clamming still strong with the annual Clam Festival and the gigantic concrete clam statue on the end of Price Street.",
                    Image="girlsguid.jpg"
                },
                new Post{
                    Title="Trips to Take in Your 20’s",
                    Text="The Yacht Week - Gather up your friends, choose a destination (British Virgin Islands, Thailand, Croatia, Greece or Italy), pick a yacht and get ready for The Yacht Week– it’s nothing like the real world! Each day you sail to a new destination and each night you party under the stars with fellow Yacht Weekers from around the world. San Fermin Festival- Pamplona, Spain - Arrive in Pamplona for the San Fermin Opening Ceremony where you will spend the morning being doused with sangria, flour and eggs and the afternoon wandering the streets filled with music and dancing. The following morning, get up early (or perhaps you stayed out all night?) and get ready for the famous ‘Running of the Bulls.’ You can either participate in the run or watch from the streets or a balcony. Inca Trail to Machu Picchu- Peru - Set off on one of the most breathtaking trails in the world. The ever-changing landscape of the Inca Trail will bring you over towering mountains and through the rainforest, only to end at the incredible Machu Picchu. Travel to Watch the World Cup - Regardless of whether you’re a diehard soccer fan or not, watching the World Cup live is a must do! Aside from the unforgettable parties and the insane energy in the stadium, what better way to unite with people from all over the world at one of the biggest sporting events on earth?",
                    Image="trips20.jpg"
                },
                new Post{
                    Title="Places to Visit in Arizona (That Aren’t the Grand Canyon)",
                    Text="Sedona -  Featured on my list of essential spots on any Southwest USA road trip, Sedona is like nowhere else you’ve ever been before. A geological wonderland and mecca for spiritualism, Sedona has a magical atmosphere. Horseshoe Bend / Antelope Canyon - Possibly one of the most photographed places in Arizona, Antelope Canyon is even more stunning in person. It’s an essential visit and only seven miles from the breathtaking lookout point that is Horseshoe Bend. Scottsdale - Fun fact: There are more spas per capita in Scottsdale than anywhere else in the US. Lounge poolside at one of many lux resorts, get a pampering treatment, then hit the town for top-notching nightlife. Tombstone - Dust off those cowboy boots and pull up a stool at the O.K. Corral. Play a game of poker or two then mosey outside to watch a shootout. Peak through the bullet holes in the old Bird Cage Theatre, a one-time brothel. When you’re here, you’re miles from the ordinary.",
                    Image="arizona.jpg"
                },
                new Post{
                    Title="Hacks for Healthier Hair",
                    Text="Don’t Wash Every Day - First things first: you don’t need to wash your hair every single day. Dry Condition Between Washes - You use dry shampoo to absorb the excess oils from your scalp and keep it looking fresh…but what about the ends of your hair? Did you know that you can also dry condition your hair? Yep! Dry conditioner is one of the best-kept secrets when it comes to hair hacks. Re-Learn How to Wash Your Hair - This may come as a shock, but it took me nearly thirty years to learn how to wash my hair correctly—or at least the right way for my hair type! Be Careful with Hair Ties - Avoid hair ties as much as possible, or opt for non-damaging options (think scrunchie-types!). While I’m a big fan of fun updos and braids—especially when it comes to no-heat hairstyles, the small elastics almost always cause breakage…which is no good!",
                    Image="hair.jpg"
                },
                new Post{
                    Title="Tips for Your First Trip to Hawaii",
                    Text="Make Sure to Try the Local Food - Already in love with your local poké restaurant? That is just the tip of the iceberg! From sweet treats like shave ice to sounds-weird-but-is-amazing Spam Musubi, Hawaii is a culinary wonderland. Don’t Try to Visit Too Many Islands in One Trip - There are so many irresistible destinations, it’s hard not to want to rush from one topical oasis to the next—but take a breath! The true beauty of Hawaii is the laid-back lifestyle. Wear Reef-Safe Sunscreen - I’ve talked before about just how crucial reef-safe sunscreen is, and I was thrilled to see that Hawaii has jumped on the bandwagon. The state actually banned sunscreen with oxybenzone and octinoxate because they cause such widespread damage to the coral reefs.",
                    Image="hawai.jpg"
                },
                new Post{
                    Title="A Local’s Guide to Amsterdam",
                    Text="Getting Around - Surprisingly, Amsterdam is a pretty small city which makes it super accessible! There are a ton of ways to get around which make exploring fun and exciting: By Bike - Biking is the most popular mode of transportation in Amsterdam and renting a bike to cruise around is the best way to immerse yourself in the locals’ ways!  By Foot - Since Amsterdam is such a small city getting around on foot is very easy. You will be tired after walking all day but if you aren’t comfortable biking but want to save money with transportation this is a good option! By Public Transportation - Amsterdam has a really good public transportation system made up of busses, trams and even an underground metro. If you plan on getting around with public transportation your best bet is to get a GVB unlimited travel card. With this, you get unlimited access to trams, busses, and the metro for a set amount. Just note this card does not count for train usage. By Car - Getting around by car is one of the least popular ways to get around Amsterdam. If you rent a car you will end up spending €25 + a day in parking alone. While Ubers are available in the city, they tend to cost quite a bit.",
                    Image="amsterdam.jpg"
                },
                new Post{
                    Title="Top Things to Do in Mo’orea",
                    Text="Rent a Beach Buggy - I had a blast cruising around in my beach buggy, and would highly recommend getting behind the wheel for at least a few hours. I didn’t actually rent a car for the rest of the trip, so having a buggy for the day was a perfect way to see the edges of the islands. Swim with Humpback Whales - From July and November, Humpback whales leave the freezing water of the Antarctic seas to find their vacation homes in the warm waters of French Polynesia. See the Rays and Reef Sharks - There is a shallow sand bar where you can stand in the crystal clear water and watch in wonder as these inquisitive little guys will come up to meet you. Visit Belvedere Lookout - Easily one of the most beautiful vantage points in French Polynesia, Belvedere Lookout is an essential selfie spot. Bring your camera and hike up for a sweeping view of Opunohu Valley as well as Cook and Opunohu Bays",
                    Image="top.jpg"
                }
            };

            var hashtag = new List<HashTag>
            {
                new HashTag
                {
                    Name="Best Friends"
                },
                new HashTag
                {
                    Name="USA"
                },
                new HashTag
                {
                    Name="Australia"
                },
                new HashTag
                {
                    Name="Greece"
                },
                new HashTag
                {
                    Name="Bucket List"
                },
                new HashTag
                {
                    Name="Europe"
                },
                new HashTag
                {
                    Name="First Trip"
                },
                new HashTag
                {
                    Name="Local Quid"
                },
                new HashTag
                {
                    Name="China"
                },
                new HashTag
                {
                    Name="Outfit"
                },
                new HashTag
                {
                    Name="Hacks"
                }
            };

            var postHashtag = new List<PostHashTag>
            {
                new PostHashTag
                {
                    Post=post.ElementAt(0),
                    HashTag=hashtag.ElementAt(3)
                },
                new PostHashTag
                {
                    Post=post.ElementAt(0),
                    HashTag=hashtag.ElementAt(5)
                },
                new PostHashTag
                {
                    Post=post.ElementAt(1),
                    HashTag=hashtag.ElementAt(2)
                },
                new PostHashTag
                {
                    Post=post.ElementAt(2),
                    HashTag=hashtag.ElementAt(4)
                },
                new PostHashTag
                {
                    Post=post.ElementAt(3),
                    HashTag=hashtag.ElementAt(1)
                },
                new PostHashTag
                {
                    Post=post.ElementAt(4),
                    HashTag=hashtag.ElementAt(0)
                },
                new PostHashTag
                {
                    Post=post.ElementAt(5),
                    HashTag=hashtag.ElementAt(0)
                },
                new PostHashTag
                {
                    Post=post.ElementAt(5),
                    HashTag=hashtag.ElementAt(1)
                },
                new PostHashTag
                {
                    Post=post.ElementAt(6),
                    HashTag=hashtag.ElementAt(3)
                },
                new PostHashTag
                {
                    Post=post.ElementAt(6),
                    HashTag=hashtag.ElementAt(5)
                },
                new PostHashTag
                {
                    Post=post.ElementAt(7),
                    HashTag=hashtag.ElementAt(1)
                },
                new PostHashTag
                {
                    Post=post.ElementAt(7),
                    HashTag=hashtag.ElementAt(5)
                },
                new PostHashTag
                {
                    Post=post.ElementAt(8),
                    HashTag=hashtag.ElementAt(10)
                },
                new PostHashTag
                {
                    Post=post.ElementAt(9),
                    HashTag=hashtag.ElementAt(1)
                },
                new PostHashTag
                {
                    Post=post.ElementAt(9),
                    HashTag=hashtag.ElementAt(6)
                },
                new PostHashTag
                {
                    Post=post.ElementAt(10),
                    HashTag=hashtag.ElementAt(7)
                },
                new PostHashTag
                {
                    Post=post.ElementAt(10),
                    HashTag=hashtag.ElementAt(5)
                }
            };

            var user = new List<User>
            {
                new User
                {
                    FirstName="Vuk",
                    LastName="Zdravkovic",
                    Email="user@gmail.com",
                    Password="f1dc735ee3581693489eaf286088b916"
                },
                new User
                {
                    FirstName="Pera",
                    LastName="Peric",
                    Email="admin@gmail.com",
                    Password="f1dc735ee3581693489eaf286088b916"
                },
                new User
                {
                    FirstName="Mika",
                    LastName="Mikic",
                    Email="user2@gmail.com",
                    Password="f1dc735ee3581693489eaf286088b916"
                }
            };

            //user
            var userUseCases = Enumerable.Range(1, 15).ToList();
            //admin
            var adminUseCases= Enumerable.Range(1, 50).ToList();

            userUseCases.ForEach(useCase => _context.UserUseCases.Add(new UserUseCase
            {
                User = user.ElementAt(0),
                IdUseCase = useCase
            }));

            userUseCases.ForEach(useCase => _context.UserUseCases.Add(new UserUseCase
            {
                User = user.ElementAt(2),
                IdUseCase = useCase
            }));

            adminUseCases.ForEach(useCase => _context.UserUseCases.Add(new UserUseCase
            {
                User = user.ElementAt(1),
                IdUseCase = useCase
            }));

            var like = new List<Like>
            {
                new Like
                {
                    Post=post.First(),
                    User=user.First()
                },
                new Like
                {
                    Post=post.ElementAt(2),
                    User=user.ElementAt(0)
                },
                new Like
                {
                    Post=post.ElementAt(1),
                    User=user.ElementAt(0)
                },
                new Like
                {
                    Post=post.ElementAt(2),
                    User=user.ElementAt(2)
                },
                new Like
                {
                    Post=post.ElementAt(6),
                    User=user.ElementAt(2)
                },
                new Like
                {
                    Post=post.ElementAt(3),
                    User=user.ElementAt(2)
                },
                new Like
                {
                    Post=post.ElementAt(3),
                    User=user.ElementAt(0)
                }
            };

            var comment = new List<Comment>
            {
                new Comment
                {
                    Text="Nice",
                    Post=post.First(),
                    User=user.ElementAt(0)
                },
                new Comment
                {
                    Text="Very nice",
                    Post=post.First(),
                    User=user.ElementAt(2)
                },
                new Comment
                {
                    Text="Very very nice",
                    Post=post.ElementAt(1),
                    User=user.ElementAt(2)
                }
            };

            _context.Users.AddRange(user);
            _context.Posts.AddRange(post);
            _context.Comments.AddRange(comment);
            _context.Likes.AddRange(like);
            _context.HashTags.AddRange(hashtag);
            _context.PostHashTags.AddRange(postHashtag);

            _context.SaveChanges();


            return Ok();
        }

    }
}
