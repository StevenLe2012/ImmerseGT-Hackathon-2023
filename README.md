# ImmersGRT 2023 Hackathon - The Pen is Mighter than the Sword
## Project philosophy 🧐

"The Pen is Mighter than the Sword" is a two-player Virtual Reality video game that merges artistic fun, competitive madness, and fitness benefits in an immersive, high-paced environment. The game integrates advanced AI technologies (DALL-E, Stable-Diffusion, Clip) and VR hand-tracking to make the art creation process easier, and it fosters group-bonding by bringing people closer together through shared artistic experiences.

## How it works 💭

In this two-player Virtual Reality game, the players compete to replicate an AI-generated image from DALL-E. They are given 20 seconds to create as accurately of a replica as they can. After which, it is sent to be refined by Stable Diffusion and then the CLIP AI model judges the winner based on the best resemblance to the original image. 
![image](https://user-images.githubusercontent.com/64396816/230783720-e0ba21f6-6bdd-4365-a1ab-bb2bc5cd0550.png)


## How we built it 🔨

The development team of six undergraduates from Stanford, Duke, and Rice University collaborated to develop this VR experience using the Unity game engine and its XR Toolkit alongside rendering software such as Blender and several AI's. The team integrated DALL-E for image generation, Stable Diffusion for image enhancement, and CLIP for AI judging, all the while being sure to have built an engaging virtual environment to immerse users while they interact with the game.
![image](https://user-images.githubusercontent.com/64396816/230783703-a0db6e7a-c3b9-45cd-bc68-6d2bb5e37a22.png)


## Challenges we ran into 🩹

Multiplayer was incredibly difficult to iterate upon, as there are limited resources on how to use the new Unity Netcode with VR. In addition, with some of the members being virtual across different time zones, we had trouble testing the Multiplayer compatabilities within such a short time period for the hackathon.

What's more, as we rely on large generative image models to provides essential features in our app such as sketch completion, we encountered huge challenges deploying pre-trained model on personal servers. For instance, we attempted to deploy Stable Diffusion model locally, yet it took 15 minutes to generate one image, drastically reducing our speed of development.

## Accomplishments that we are proud of 😆

- Outreaching to students from different schools to gain a wider experience-base
- Teaching each other our own tricks
- Brainstorming and successfully integrating DALL-E, Stable Diffusion, and CLIP all into a single immersive VR experience
- Building an engaging virtual environment that fosters greater creativity and enhances artistic skill development

## What we learned 📙

We learned the importance of teamwork, communication, and time management in creating a successful VR project. We found it essential to correctly spread out their roles, crucial to help each other out, and even more vital to work together towards the same goal. Through challenging themselves during this hackathon, they have gained valuable experience in integrating various AI technologies, building immersive and seamless VR experiences, and, more than anything, learned why teamwork makes the dream work.

## What's next for "The Pen is Mighter than the Sword" 📈

We plan to add more features to "The Pen is Mightier," such as customizable time limits, difficulty levels, custom prompts/image categories, and more game modes. They also aim to potentially transform the art creation process from 2-dimensional to 3-dimensional, adding a whole new level of complexity to the project.

## Built with

- C# for Unity
- CLIP
- DALL-E
- Flask
- Netcode
- Python
- Pytorch
- Stable Diffusion
- Unity

## Team
[Darius Huang](https://www.linkedin.com/in/dariushuang/)
[Emmanuel Corona](https://www.linkedin.com/in/emmanuel-angel-corona-moreno/)
[Peter Cao](https://www.linkedin.com/in/ye-peter-cao-98870920b/)
[Steven Le](https://www.linkedin.com/in/stevenle1337/)
[Vencent Vang](https://www.linkedin.com/in/vencent-vang-839792254/)

## Links
[GitHub Repo](https://github.com/yourusername/your-repo-name)
[Devpost](https://devpost.com/software/the-pen-is-mighter-than-the-sword)
