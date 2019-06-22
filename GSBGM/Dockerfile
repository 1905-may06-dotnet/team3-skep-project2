FROM node:lts-alpine AS base

WORKDIR /app
COPY ./ .
RUN npm ci
RUN npm run build:ci

#CMD ["ash"]
FROM nginx:stable-alpine

COPY --from=base /app/dist /usr/share/nginx/html
COPY ./setup.sh ./
RUN apk add certbot
ENV DomainName=none
EXPOSE 80
EXPOSE 443

STOPSIGNAL SIGTERM

CMD ["sh", "./setup.sh", DomainName]
#CMD ["nginx", "-g", "daemon off;"]
