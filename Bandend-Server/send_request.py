
##################### Template: Dall-e Image generation request ###########################

# import requests

# url = 'http://127.0.0.1:5000/api_call'
# headers = {'Content-Type': 'application/json'}
# data = {
#     'request type': 'dall-e generate challenge image',
#     'request content': 'a monkey writing shakespear on the computer screen',
# }

# response = requests.post(url, json=data, headers=headers)

# if response.status_code == 200:
#     print("Request sent successfully:", response.json())
# else:
#     print("Request failed:", response.status_code, response.text)


##################### Template: Stable diffusion image perfection request ###########################

# import requests
# import json

# url = 'http://127.0.0.1:5000/api_call'
# image_path = '/Users/yecao/Desktop/imgt/ImmerseGT-Hackathon-2023/Bandend-Server/user_raw_imgs/user1_raw_duck.jpg'
# image_name = 'user1_raw_duck.jpg'

# # Set the request data
# data = {
#     'request type': 'stable diffusion generate image given image and text prompt',
#     'text prompt': "side profile, whole body, color the duck, simplified style, plain white background,  anthro, very cute kid's film character, disney pixar zootopia character concept artwork, 3d concept, detailed fur, high detail iconic character for upcoming film, trending on artstation, character design, 3d artistic render, highly detailed, octane, blender, cartoon, shadows, lighting", # hard-coded for user by us
# }

# print("sending to server")

# with open(image_path, 'rb') as image_file:
#     files = {'image': (image_name, image_file)}
#     print("file prepared")
#     response = requests.post(url, data=data, files=files)


# if response.status_code == 200:
#     print("Request sent successfully:", response.json())
# else:
#     print("Request failed:", response.status_code, response.text)


##################### Template: clip compare similarity ###########################

import requests
import json

url = 'http://127.0.0.1:5000/api_call'
dalle_image_path = '/Users/yecao/Desktop/imgt/ImmerseGT-Hackathon-2023/Bandend-Server/user_raw_imgs/user1_raw_duck.jpg'
dalle_image_name = 'user1_raw_duck.jpg'

user_image_path = '/Users/yecao/Desktop/imgt/ImmerseGT-Hackathon-2023/Bandend-Server/user_raw_imgs/user2_raw_duck.png'
user_image_name = 'user2_raw_duck.jpg'

# Set the request data
data = {
    'request type': 'clip compares similarity between dall-e image and user image'
}

print("sending to server")

with open(dalle_image_path, 'rb') as dalle_image_file, open(user_image_path, 'rb') as user_image_file:
    files = {
        'dalle_image': (dalle_image_name, dalle_image_file),
        'user_image': (user_image_name, user_image_file)
    }
    print("files prepared")
    response = requests.post(url, data=data, files=files)

if response.status_code == 200:
    print("Request sent successfully:", response.json())
else:
    print("Request failed:", response.status_code, response.text)

