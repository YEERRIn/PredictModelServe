# PredictModelServe
1. 라이브러리 설치 후 이동
```python
pip install -r requirements.txt
cd predictAPI
```

<br>

2. fastAPI 서버 on
```python
uvicorn run:app --reload
```
<br>

3. 유니티 스크립트 실행
```python
/get_on_predict → 승차 인원 예측 
/get_off_predict → 하차 인원 예측
```
