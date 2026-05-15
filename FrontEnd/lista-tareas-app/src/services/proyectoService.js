import api from "./api";

const endpoit = "/proyectos";

export const getProyectos = async () => {
  const response = await api.get(endpoit);
  return response.data;
};
