# base image
FROM node:12.15.0-alpine as react-build

WORKDIR /app
COPY . ./
RUN npm install --silent
RUN npm run-script build

# Stage 2 - the production environment
FROM nginx:alpine
COPY nginx.conf /etc/nginx/conf.d/default.conf
COPY --from=react-build /app/build /usr/share/nginx/html
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]