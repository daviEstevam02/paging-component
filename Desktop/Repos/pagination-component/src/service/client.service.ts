import { api, endpoints } from "../utils";

export const getAllClients = (skip: any, top:any) => {
    const endpoint = endpoints.CLIENTS.GET_ALL
    .replace(':skip', skip)
    .replace(':top', top)
    return api.get(endpoint)
}