import axios from "axios";
import { API_URL } from "../config/env";

const api = axios.create({
  baseURL: API_URL,
  headers: {
    "Content-Type": "application/json",
  },
});

api.interceptors.request.use(
  (config) => {
    console.log("Request", config.url);
    return config;
  },
  (error) => {
    console.log(error);
    return Promise.reject(error);
  },
);

api.interceptors.response.use(
  (response) => {
    console.log("Response", response.config.url);
    return response;
  },
  (error) => {
    console.log("Api error", error);

    if (error.response) {
      switch (error.response.status) {
        case 401:
          console.log("No autorizado");
          break;
        case 404:
          console.log("No encontrado");
          break;

        case 500:
          console.log("Error interno del servidor");
          break;
      }
    }
    return Promise.reject(error);
  },
);

export default api;
