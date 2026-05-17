import api from "./api";

const endpoint = "/proyectos";

export const getProyectos = async () => {
  const response = await api.get(endpoint);
  return response.data;
};

export const createProyecto = async (data) => {
  const response = await api.post(endpoint, data);
  return response.data;
};

export const updateProyecto = async (id, data) => {
  const response = await api.put(endpoint, data, { params: { id } });
  return response.data;
};

export const deleteProyecto = async (id) => {
  const response = await api.delete(endpoint, { params: { id } });
  return response.data;
};
