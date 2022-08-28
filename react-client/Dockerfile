FROM node:16-alpine as builder

WORKDIR /react-client-app

COPY package.json ./

RUN npm install --only=prod

COPY . ./

RUN npm run build

FROM nginx:1.16.0-alpine

COPY --from=builder ./ /usr/share/nginx/html

EXPOSE 3000
EXPOSE 8080

CMD ["nginx", "-g", "daemon off;"]