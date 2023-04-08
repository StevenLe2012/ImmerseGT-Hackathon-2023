import torch
import torchvision.transforms as transforms
from PIL import Image
from transformers import CLIPProcessor, CLIPModel

def load_image(image_path):
    image_transform = transforms.Compose([
        transforms.Resize(224, Image.BICUBIC),
        transforms.CenterCrop(224),
        transforms.ToTensor(),
        transforms.Normalize((0.48145466, 0.4578275, 0.40821073), (0.26862954, 0.26130258, 0.27577711)),
    ])
    image = Image.open(image_path).convert("RGB")
    return image_transform(image).unsqueeze(0)

def image_similarity(image1_path, image2_path):
    device = "cuda" if torch.cuda.is_available() else "cpu"

    model = CLIPModel.from_pretrained("openai/clip-vit-base-patch32").to(device)
    processor = CLIPProcessor.from_pretrained("openai/clip-vit-base-patch32")

    image1_tensor = load_image(image1_path).to(device)
    image2_tensor = load_image(image2_path).to(device)

    with torch.no_grad():
        image1_features = model.get_image_features(image1_tensor)
        image2_features = model.get_image_features(image2_tensor)

        similarity = torch.nn.functional.cosine_similarity(image1_features, image2_features)

    return similarity.item()

