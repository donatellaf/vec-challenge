import AxiosInstance from "./../axios";

export const getCollection = (module, params) => async () => {
  try {
    return await AxiosInstance.get(`${module}/getAll?PageSize=1000`, {
      params: params,
    });
  } catch (err) {
    throw err;
  }
};

export const getCollectionById = (module, id) => async () => {
  try {
    return await AxiosInstance.get(`${module}/GetById/${id}`);
  } catch (err) {
    throw err;
  }
};

export const post = (module, data) => async () => {
  try {
    return await AxiosInstance.post(`${module}/SaveNewEntity`, data);
  } catch (err) {
    throw err;
  }
};

export const remove = (module, id) => async () => {
  try {
    return await AxiosInstance.delete(`${module}/DeleteById?id=${id}`);
  } catch (err) {
    throw err;
  }
};

export const putApi = (module, id, data) => async () => {
  try {
    return await AxiosInstance.put(`${module}/UpdateEntity?id=${id}`, data);
  } catch (err) {
    throw err;
  }
};
