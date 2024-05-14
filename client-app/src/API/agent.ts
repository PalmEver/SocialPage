import axios, { AxiosResponse } from "axios";
import { create } from "domain";
import { Post } from "../components/models/post";
import { Users } from "../components/models/user"

axios.defaults.baseURL = 'http://localhost:5000/api';

const responseBody = <T>(response: AxiosResponse<T>) => response.data;

const requests = {
    get: <T>(url: string) => axios.get<T>(url).then(responseBody),
    post: <T>(url: string, body: {}) => axios.post<T>(url).then(responseBody),
    put: <T>(url: string, body: {}) => axios.put<T>(url).then(responseBody),
    del: <T>(url: string) => axios.delete<T>(url).then(responseBody)
}

const Posts = {
    list: () => requests.get<Post[]>('/posts'),
    listUser: (id: number) => requests.get<Post[]>(`/posts/follow/${id}`),
    details: (id: string) => requests.get<Post>(`/posts/${id}`),
    create: (post: Post) => requests.post<void>('/posts', post),
    edit: (post: Post) => requests.put<void>(`/posts/${post.id}`, post),
    delete: (id: string) => requests.del<void>(`/posts${id}`)
}

const Users = {
    register: (user: Users) => requests.post<void>('/Auth/register', user),
    login: (email: string,) => requests.post<Post>('/Auth/login', email),
    getUser: (id: number) => requests.get<void>(`/Auth/user/${id}`),
    logout: (user: Users) => requests.post<void>('Auth/logout', user)
}

const agent = {
    Posts,
    Users
}

export default agent;