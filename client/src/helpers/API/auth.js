import axios from 'axios'

const server = process.env.REACT_APP_SERVER

export const signInApi = async values => {
  const res = { data: '', status: 200 }
  try {
    const val = await axios.post(`${server}/Auth/login`, {
      ...values,
    })

    res.data = val.data
    res.status = val.status
  } catch (error) {
    res.data = error.message
    res.status = error.response.status
  }

  return res
}

export const signUpApi = async values => {
  const res = { data: '', status: 200 }
  try {
    const val = await axios.post(`${server}/Auth/signup`, {
      ...values,
    })

    res.data = val.data
    res.status = val.status
  } catch (error) {
    res.data = error.message
    res.status = error.response.status
  }

  console.log(res)

  return res
}
