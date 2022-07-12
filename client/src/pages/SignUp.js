import {
  Avatar,
  Button,
  Container,
  makeStyles,
  TextField,
  Toolbar,
  Typography,
} from '@material-ui/core'
import { useFormik } from 'formik'
import { signUpValidation } from '../helpers/yupValidation'
import LockOutlinedIcon from '@material-ui/icons/LockOutlined'
import NavBar from '../components/NavBar'
import { useLocation, useNavigate } from 'react-router-dom'
import { signUpApi } from '../helpers/API/auth'

const useStyles = makeStyles(theme => ({
  paper: {
    marginTop: theme.spacing(3),
    display: 'flex',
    flexDirection: 'column',
    alignItems: 'center',
  },
  form: {
    width: '100%', // Fix IE 11 issue.
    marginTop: theme.spacing(1),
  },
  submit: {
    margin: theme.spacing(3, 0, 2),
  },
  avatar: {
    margin: theme.spacing(1),
    backgroundColor: theme.palette.secondary.main,
  },
}))

export default function SignUp(props) {
  const classes = useStyles()
  const { pathname } = useLocation()
  const navigate = useNavigate()

  const formik = useFormik({
    initialValues: {
      name: '',
      empId: '',
      email: '',
      password: '',
      confirmPassword: '',
      designation: '',
      officeLocation: '',
    },
    validationSchema: signUpValidation,
    onSubmit: values => {
      handleSignUp(values)
    },
  })

  // this handles sign up by calling the signup api
  const handleSignUp = async values => {
    values.empId = parseInt(values.empId)
    const res = await signUpApi(values)

    if (res.status === 200) {
      alert('Sign Up successfull, please sign in to continue...')
      navigate('/signin')
    } else {
      alert('An error occurred, please try again...')
    }
  }

  return (
    <div>
      <NavBar path={pathname} />
      <Toolbar />
      <Container component='main' maxWidth='sm'>
        <div className={classes.paper}>
          <Avatar className={classes.avatar}>
            <LockOutlinedIcon />
          </Avatar>
          <Typography component='h1' variant='h5'>
            Sign Up
          </Typography>

          <div style={{ width: '100%' }}>
            <form className={classes.form} onSubmit={formik.handleSubmit}>
              <TextField
                variant='outlined'
                fullWidth
                margin='normal'
                id='name'
                name='name'
                label='Name'
                value={formik.values.name}
                onChange={formik.handleChange}
                error={formik.touched.name && Boolean(formik.errors.name)}
                helperText={formik.touched.name && formik.errors.name}
              />

              <TextField
                variant='outlined'
                fullWidth
                margin='normal'
                id='empId'
                name='empId'
                label='Employee Id'
                value={formik.values.empId}
                onChange={formik.handleChange}
                error={formik.touched.empId && Boolean(formik.errors.empId)}
                helperText={formik.touched.empId && formik.errors.empId}
              />

              <TextField
                variant='outlined'
                fullWidth
                margin='normal'
                id='email'
                name='email'
                label='Email'
                value={formik.values.email}
                onChange={formik.handleChange}
                error={formik.touched.email && Boolean(formik.errors.email)}
                helperText={formik.touched.email && formik.errors.email}
              />

              <TextField
                variant='outlined'
                fullWidth
                margin='normal'
                id='password'
                name='password'
                label='Password'
                value={formik.values.password}
                onChange={formik.handleChange}
                error={
                  formik.touched.password && Boolean(formik.errors.password)
                }
                helperText={formik.touched.password && formik.errors.password}
              />

              <TextField
                variant='outlined'
                fullWidth
                margin='normal'
                id='confirmPassword'
                name='confirmPassword'
                label='Confirm Password'
                value={formik.values.confirmPassword}
                onChange={formik.handleChange}
                error={
                  formik.touched.confirmPassword &&
                  Boolean(formik.errors.confirmPassword)
                }
                helperText={
                  formik.touched.confirmPassword &&
                  formik.errors.confirmPassword
                }
              />

              <TextField
                variant='outlined'
                fullWidth
                margin='normal'
                id='designation'
                name='designation'
                label='Designation'
                value={formik.values.designation}
                onChange={formik.handleChange}
                error={
                  formik.touched.designation &&
                  Boolean(formik.errors.designation)
                }
                helperText={
                  formik.touched.designation && formik.errors.designation
                }
              />

              <TextField
                variant='outlined'
                fullWidth
                margin='normal'
                id='officeLocation'
                name='officeLocation'
                label='Office Location'
                value={formik.values.officeLocation}
                onChange={formik.handleChange}
                error={
                  formik.touched.officeLocation &&
                  Boolean(formik.errors.officeLocation)
                }
                helperText={
                  formik.touched.officeLocation && formik.errors.officeLocation
                }
              />

              <Button
                type='submit'
                fullWidth
                variant='contained'
                color='primary'
                className={classes.submit}
              >
                Sign Up
              </Button>
            </form>
          </div>
        </div>
      </Container>
    </div>
  )
}
