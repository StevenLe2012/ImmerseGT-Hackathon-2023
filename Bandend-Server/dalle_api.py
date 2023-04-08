import requests
import json
import os

def generate_dalle_image(prompt):
    # Set your OpenAI API key
    api_key = os.environ.get('OPENAI_API_KEY')
    #api_key = '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'
    print("API key is")
    print(api_key)


    # Set the API endpoint
    url = 'https://api.openai.com/v1/images/generations'

    # Set the model and parameters
    model = 'image-alpha-001'
    params = {
        'model': model,
        'prompt': prompt,
        'num_images': 1,
        'size': '512x512',
    }

    # Set the headers and data
    headers = {
        'Content-Type': 'application/json',
        'Authorization': f'Bearer {api_key}',
    }
    data = json.dumps(params)

    # Make the API request
    response = requests.post(url, headers=headers, data=data)

    print("this is the response")
    print(response.json())

    # Get the generated image URL from the response
    image_url = response.json()['data'][0]['url']

    # Return the image URL
    return image_url
