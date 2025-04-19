FROM node:18-alpine

ENV NODE_ENV=production

WORKDIR ./usr/src/app

# Copy package.json and package-lock.json
COPY package*.json ./

# Now install the dependencies
RUN npm install --omit=dev

# Copy the remaining application files
COPY . .

EXPOSE 3000

RUN chown -R node /usr/src/app

USER node

CMD [ "npm", "run", "dev" ]
