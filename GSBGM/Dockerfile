FROM node:lts-alpine AS base

WORKDIR /app
COPY ./ .
RUN npm ci
RUN npm run build:ci

FROM nginx:stable-alpine

COPY ./default.conf /etc/nginx/conf.d
COPY --from=base /app/dist/GSBGM /usr/share/nginx/html
EXPOSE 80
EXPOSE 443

STOPSIGNAL SIGTERM

CMD ["ash"]
#CMD ["nginx", "-g", "daemon off;"]
