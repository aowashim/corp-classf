import * as yup from 'yup'

const emailValidTxt = 'Must be valid email'

export const signUpValidation = yup.object({
  name: yup.string().max(20).required('Name is required'),
  email: yup.string().email(emailValidTxt).required('Email is required'),
  password: yup
    .string()
    .required('Password is required')
    .matches(
      /^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#\$%\^&\*])(?=.{6,})/,
      'Must Contain 6 Characters, One Uppercase, One Lowercase, One Number and One Special Case Character'
    ),
  confirmPassword: yup
    .string()
    .oneOf([yup.ref('password'), null], 'Passwords must match'),
  designation: yup.string().max(20).required('Designation is required'),
  officeLocation: yup
    .string()
    .max(30, 'Office Location must be at most 30 characters')
    .required('Office Location is required'),
})

export const signInValidation = yup.object({
  email: yup.string().email(emailValidTxt).required('Email is required'),
  password: yup
    .string()
    .required('Password is required')
    .matches(
      /^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#\$%\^&\*])(?=.{6,})/,
      'Must Contain 6 Characters, One Uppercase, One Lowercase, One Number and One Special Case Character'
    ),
})
