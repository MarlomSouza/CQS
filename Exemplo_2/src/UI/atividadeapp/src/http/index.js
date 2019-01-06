import axios from 'axios'

// create a new axios instance
const instance = axios.create({
  baseURL: 'https://localhost:5001/api/atividades',
  timeout: 10000
})

// before a request is made start the nprogress
instance.interceptors.request.use(config => {
  console.log('iniciou transação LOADING')
  return config
})

// before a response is returned stop nprogress
instance.interceptors.response.use(response => {
  console.log('FINALIZOU transação LOADING')
  return response
})

export default instance
