import axios from 'axios'
import { configAxios } from '../constant'

const server = process.env.REACT_APP_SERVER_OFFER

export const postOfferApi = async (values, category_Id, emp_Id) => {
  const res = { data: '', status: 200 }

  const sd = new Date(values.startDate)
  const start_Date = sd.toJSON()

  const ed = new Date(values.endDate)
  const end_Date = ed.toJSON()

  const jsonData = {
    title: values.title,
    description: values.description,
    n_Likes: 0,
    start_Date,
    end_Date,
    category_Id,
    emp_Id: parseInt(emp_Id),
  }

  try {
    const val = await axios.post(`${server}/addOffer`, jsonData, configAxios())

    res.data = val.data
    res.status = val.status
  } catch (error) {
    res.data = error.message
    res.status = error.response.status
  }

  return res
}

export const getAllOfferApi = async endPoint => {
  const res = { data: '', status: 200 }

  try {
    const val = await axios.get(`${server}/${endPoint}`, configAxios())

    res.data = val.data
    res.status = val.status
  } catch (error) {
    res.data = error.message
    res.status = error.response.status
  }

  return res
}

export const getOfferDetailsApi = async id => {
  const res = { data: '', status: 200 }

  try {
    const val = await axios.get(
      `${server}/getOfferDetails/${id}`,
      configAxios()
    )

    res.data = val.data
    res.status = val.status
  } catch (error) {
    res.data = error.message
    res.status = error.response.status
  }

  console.log(res)

  return res
}

export const editOfferApi = async (values, category_Id, offerId) => {
  const res = { data: '', status: 200 }

  const sd = new Date(values.startDate)
  const start_Date = sd.toJSON()

  const ed = new Date(values.endDate)
  const end_Date = ed.toJSON()

  const jsonData = {
    title: values.title,
    description: values.description,
    start_Date,
    end_Date,
    category_Id,
  }

  try {
    const val = await axios.post(
      `${server}/editOffer?id=${offerId}`,
      jsonData,
      configAxios()
    )

    res.data = val.data
    res.status = val.status
  } catch (error) {
    res.data = error.message
    res.status = error.response.status
  }

  return res
}

export const postCommentApi = async (content, user_Id, offer_Id) => {
  const res = { data: '', status: 200 }

  user_Id = parseInt(user_Id)
  offer_Id = parseInt(offer_Id)

  try {
    const val = await axios.post(
      `${server}/comment`,
      {
        content,
        user_Id,
        offer_Id,
      },
      configAxios()
    )

    res.data = val.data
    res.status = val.status
  } catch (error) {
    res.data = error.message
    res.status = error.response.status
  }

  return res
}

export const getCommentsApi = async id => {
  const res = { data: '', status: 200 }

  try {
    const val = await axios.get(`${server}/comments/${id}`, configAxios())

    res.data = val.data
    res.status = val.status
  } catch (error) {
    res.data = error.message
    res.status = error.response.status
  }

  return res
}

export const likeOfferApi = async (empId, ofId) => {
  const res = { data: '', status: 200 }

  try {
    const val = await axios.post(
      `${server}/engageOffer?Id=${ofId}&Emp_Id=${empId}`,
      {},
      configAxios()
    )

    res.data = val.data
    res.status = val.status
  } catch (error) {
    res.data = error.message
    res.status = error.response.status
  }

  return res
}
