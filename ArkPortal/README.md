Build docker container and run.
Clone repo
cd arkuserportal/ArkPortal
docker build -t arkuserportal .
docker run -p 5000:80 -v /storage/:/game_files/ -d arkuserportal