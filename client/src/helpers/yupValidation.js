import * as yup from 'yup'

const emailValidTxt = 'Must be valid email'

export const signUpValidation = yup.object({
  name: yup.string().max(20).required('Name is required'),
  empId: yup
    .number()
    .typeError('Employee Id must be a integer')
    .required('Employee Id is required'),
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
  empId: yup
    .number()
    .typeError('Employee Id must be a integer')
    .required('Employee Id is required'),
  password: yup
    .string()
    .required('Password is required')
    .matches(
      /^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#\$%\^&\*])(?=.{6,})/,
      'Must Contain 6 Characters, One Uppercase, One Lowercase, One Number and One Special Case Character'
    ),
})

export const postOfferValidation = yup.object({
  title: yup.string().required('Title is required').max(50),
  description: yup.string().required('Description is required').max(200),
  startDate: yup
    .string()
    .matches(
      /^(0?[1-9]|1[0-2])\/(0?[1-9]|1\d|2\d|3[01])\/(19|20)\d{2}$/,
      'Please enter date in mm/dd/yyyy format'
    )
    .required('Start Date is required'),
  endDate: yup
    .string()
    .matches(
      /^(0?[1-9]|1[0-2])\/(0?[1-9]|1\d|2\d|3[01])\/(19|20)\d{2}$/,
      'Please enter date in mm/dd/yyyy format'
    )
    .required('End Date is required'),
  // category: yup.string().required('Category is required'),
})

export const postCommentValidation = yup.object({
  comment: yup.string().required('Comment is required').max(100),
})
