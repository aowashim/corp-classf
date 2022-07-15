export const appPrimary = '#b69bff'
export const appBackground = '#d8c9ff'
export const appCardColor = '#f0ebff'

export const configAxios = () => {
  const token = localStorage.getItem('token')

  return {
    headers: {
      Authorization: 'Bearer ' + token,
    },
  }
}

export const sesExpMsg = 'Your session has expired, please login again...'
