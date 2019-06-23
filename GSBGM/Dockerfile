FROM node:lts-alpine AS base

WORKDIR /app
COPY ./ .
RUN npm ci
RUN npm run build:ci

FROM nginx:stable-alpine

COPY --from=base /app/dist /usr/share/nginx/html
EXPOSE 80
EXPOSE 443

STOPSIGNAL SIGTERM

#CMD ["ash"]
#CMD ["/setup.sh", DomainName]
CMD ["nginx", "-g", "daemon off;"]
