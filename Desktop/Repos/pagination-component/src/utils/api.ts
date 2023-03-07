import axios from "axios";

export const api = axios.create({
    baseURL: 'http://easydocswebapi-dev.eba-5nyatrca.us-east-1.elasticbeanstalk.com/'
})