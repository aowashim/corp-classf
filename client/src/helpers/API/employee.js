import axios from 'axios'

const server = process.env.REACT_APP_SERVER_EMP

export const getEmpProfileApi = async id => {
  const res = { data: '', status: 200 }

  try {
    const val = await axios.get(`${server}/ViewProfile/${id}`)

    res.data = val.data
    res.status = val.status
  } catch (error) {
    res.data = error.message
    res.status = error.response.status
  }

  return res
}
