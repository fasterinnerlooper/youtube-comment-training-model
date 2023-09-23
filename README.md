# Introduction
A command-line tool to categorise YouTube comments by their psychological safety. For comments that are determined to have a low psychological safety, a description of the comment is given, and not repeated verbatim.

# Usage
Requires .NET 6+ runtime. Download via the install scripts here: https://dotnet.microsoft.com/en-us/download/dotnet/scripts

Use the following command to install the runtime:
## Pre-requisites

## Windows
`dotnet-install.ps1 --runtime dotnet`
## Linux
`dotnet-install.sh --runtime dotnet`

## Running the application

`dotnet run <VIDEO_ID> <YOUTUBE_API_KEY> <OPENAI_API_KEY>`

## Example response
Run against video ID CmYKJpKsh_c

High Psychological Safety:
- Great video as always but why is poor Jango posed like he needs to use the toilet
- I like it, thanks for showing the comparison. Definitely be getting the Batman. As always, your builds and opinions are greatly appreciated.
- You answered a question I was wondering about.
- Hi again! Im a really big fan of your videos! You inspired me to build my own lego city and to buy many lego sets!!!!??????
- I love this. I just wish lego would make some figures for other technic sets
- I literally just got these two sets, Batman figure and his bike, yesterday! Now I know for sure they will look good enough to be displayed together. Thank you for the video.
- Got both the Ducati, and Batcycle earlier in Summer. While both display great on their own, i too was curious how they would scale to the newest buildable figures. I was thinking the bike would be too small, but the scaling is much closer than initially thought. Balance looks to be a bit of an issue but cool to see the comparison shots. Definitely getting the Batman now, and maybe the Captain America as he looks like a good fit for the Ducati as both bikes are very similar in size.
- Thanks for this video. Really answered the question that has been on my mind for some time. Nice job

Medium Psychological Safety:
- Hi. Unrelated question. But when are we going to hear any news about the speed champions 2024?
- Actually, combining construction figures with Technic motorcycles is not a new idea, and can be a fun way to waste some time. Your own Darth Vader Chopper inspired me to put some Star Wars buildable figures on some of the older Technic motorbikes and the results look pretty cool. I've put a New Order StormTrooper on an orange Dirtbike and a Pretorian Guard (the ones with the weird helmets and red robes) on a Streetracer and on the Ducati. The Batcycle is still waiting to be built, and I was thinking it would become Darth Vader's bike with some small modifications. Now what vehicle would I put General Grievous on?
- I wish Darth Vader had a motorbike of his own ??
- I think it would have been pretty cool if they released both these products in a single set, which could have lowered the total price perhaps
- Lol that split on two bikes frame xD
- I like it might only get those sets only for that

Low Psychological Safety (paraphrased):
- All of these lego figures are not as appealing as I'd like them to be. It would be great if they improved them in the future.
- Those buildable figures have ugly design and the proportions are off too. Improvement is needed.
- All of these lego figures are garbage. I wish they came up with a replacement for the old technic figures.