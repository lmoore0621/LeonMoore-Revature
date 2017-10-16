#!/bin/bash

# update package definition.
sudo apt-get update

# install package dependencies.
sudo apt-get install -y \
  apt-transport-https \
  ca-certificates \
  curl \
  software-properties-common

# add docker official gpg key.
curl -fsSL https://download.docker.com/linux/ubuntu/gpg | sudo apt-key add -

# add docker repository.
sudo add-apt-repository \
  "deb [arch=amd64] https://download.docker.com/linux/ubuntu $(lsb_release -cs) stable"

# install docker engine binary.
sudo apt-get update
sudo apt-get install -y \
  docker-ce=17.06.2~ce-0~ubuntu

# install docker compose binary.
sudo apt-get update
sudo curl --silent --location \
  https://github.com/docker/compose/releases/download/1.16.1/docker-compose-`uname -s`-`uname -m` > \
  /tmp/docker-compose
sudo chmod +x /tmp/docker-compose
sudo cp /tmp/docker-compose /usr/local/bin/docker-compose

# install docker machine binary.
sudo apt-get update
sudo curl --silent --location \
  https://github.com/docker/machine/releases/download/v0.12.2/docker-machine-`uname -s`-`uname -m` > \
  /tmp/docker-machine
sudo chmod +x /tmp/docker-machine
sudo cp /tmp/docker-machine /usr/local/bin/docker-machine
