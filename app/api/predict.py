from fastapi import APIRouter
from app.schemas.predict import PredictRequest
from app.models.prophet_model import load_model, make_prediction


router = APIRouter()
model = load_model()

@router.post("/predict")
def predict(data: PredictRequest):
    return make_prediction(model, data)


