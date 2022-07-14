export const appPrimary = '#b69bff'
export const appBackground = '#d8c9ff'
export const appCardColor = '#f0ebff'

export const configAxios = {
  headers: {
    Authorization: 'Bearer ' + localStorage.getItem('token'),
  },
}

export const sesExpMsg = 'Your session has expired, please login again...'
