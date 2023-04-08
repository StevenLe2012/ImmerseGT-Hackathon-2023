
##################### Template: Dall-e Image generation request ###########################

import requests

url = 'http://127.0.0.1:5000/api_call'
headers = {'Content-Type': 'application/json'}
data = {
    'request type': 'dall-e generate challenge image',
    'request content': 'a monkey writing shakespear on the computer screen',
}

response = requests.post(url, json=data, headers=headers)

if response.status_code == 200:
    print("Request sent successfully:", response.json())
else:
    print("Request failed:", response.status_code, response.text)


##################### Template: Stable diffusion image perfection request ###########################

# import requests
# import json

# url = 'http://127.0.0.1:5000/api_call'
# image_path = '/Users/yecao/Desktop/imgt/ImmerseGT-Hackathon-2023/Bandend-Server/user_raw_imgs/user1_raw_duck.jpg'
# image_name = 'user1_raw_duck.jpg'

# # Set the request data
# data = {
#     'request type': 'stable diffusion generate image given image and text prompt',
#     'text prompt': 'a monkey typing on the keyboard', # hard-coded for user by us
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


#####################  ###########################
