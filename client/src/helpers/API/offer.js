import axios from 'axios'

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
    const val = await axios.post(`${server}/addOffer`, jsonData)

    res.data = val.data
    res.status = val.status
  } catch (error) {
    res.data = error.message
    res.status = error.response.status
  }

  return res
}

export const getAllOfferApi = async () => {
  const res = { data: '', status: 200 }
  try {
    const val = await axios.get(`${server}/offer`)

    res.data = val.data
    res.status = val.status
  } catch (error) {
    res.data = error.message
    res.status = error.response.status
  }

  return res
}