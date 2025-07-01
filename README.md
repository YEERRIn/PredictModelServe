# PredictModelServe
Prophet model serving 

시작
uvicorn run:app --reload

결과 예시(콘솔로그) 
예측 결과: [{"ds":"2025-07-01T14:15:05","yhat":732.585095245704,"yhat_lower":485.5762127830055,"yhat_upper":977.9168126105307}]

yhat:예측값
yhat_lower: 하한값
yhat_upper: 상한값
