import axios from 'axios'
import NProgress from 'nprogress'

// create a new axios instance
const instance = axios.create({
  baseURL: 'https://localhost:5001/api/atividades'
})

// before a request is made start the nprogress
instance.interceptors.request.use(config => {
  NProgress.start()
  return config
})

// before a response is returned stop nprogress
instance.interceptors.response.use(response => {
  NProgress.done()
  return response
}, () => NProgress.done())

export default instance
