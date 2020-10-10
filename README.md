# MeetMe.Agents


## How to run application :
To run this app in docker you should clone this repo and run : 

```
docker-compose -f infrastructure.yml up -d
```

This instructions prepare infrastructure to debug and work with application. 
Then you should just build container and run with port redirection and with network :

```
docker build -t meetMe:1.0 .

docker run --network=meetMe-network -p 5000:5000 meetMe:1.0
```
