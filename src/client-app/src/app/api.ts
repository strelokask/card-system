import { Client } from "./ApiBase";

export const apiClient = new Client("http://localhost:5000", {
  async fetch(url: RequestInfo, init: RequestInit) {
    // const accessToken = await acquireAccessToken();

    // if (accessToken) init.headers['Authorization'] = `Bearer ${accessToken}`;

    return fetch(url, init);
  },
});
