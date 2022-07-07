import React, { useContext } from 'react'
import Avatar from '@material-ui/core/Avatar'
import Button from '@material-ui/core/Button'
import TextField from '@material-ui/core/TextField'
import Box from '@material-ui/core/Box'
import LockOutlinedIcon from '@material-ui/icons/LockOutlined'
import Typography from '@material-ui/core/Typography'
import { makeStyles } from '@material-ui/core/styles'
import Container from '@material-ui/core/Container'
import { useFormik } from 'formik'
import { signInValidation } from '../helpers/yupValidation'
import { Link, useLocation } from 'react-router-dom'
import NavBar from '../components/NavBar'
import { Toolbar } from '@material-ui/core'
import { signInApi } from '../helpers/API/auth'
import UserContext from '../store/UserContext'

function Copyright() {
  return (
    <Typography variant='body2' color='textSecondary' align='center'>
      {'Copyright © '}
      <a href='https://mui.com/'>Corporate Classifieds</a>{' '}
      {new Date().getFullYear()}
      {'.'}
    </Typography>
  )
}

const useStyles = makeStyles(theme => ({
  paper: {
    marginTop: theme.spacing(8),
    display: 'flex',
    flexDirection: 'column',
    alignItems: 'center',
  },
  avatar: {
    margin: theme.spacing(1),
    backgroundColor: theme.palette.secondary.main,
  },
  form: {
    width: '100%', // Fix IE 11 issue.
    marginTop: theme.spacing(1),
  },
  submit: {
    margin: theme.spacing(3, 0, 2),
  },
}))

export default function SignIn() {
  const classes = useStyles()
  const { pathname } = useLocation()
  const { user, setUser } = useContext(UserContext)

  const formik = useFormik({
    initialValues: {
      empId: '',
      password: '',
    },
    validationSchema: signInValidation,
    onSubmit: values => {
      handleSignIn(values)
      // console.log(values)
    },
  })

  // this handles sign in by calling the signin api
  const handleSignIn = async values => {
    const res = await signInApi(values)

    if (res.status === 200) {
      localStorage.setItem('token', res.data)
      localStorage.setItem('id', values.empId)

      setUser({
        id: values.empId,
        token: res.data,
      })
    }
  }

  return (
    <div>
      <NavBar path={pathname} />
      <Toolbar />
      <Container component='main' maxWidth='xs'>
        <div className={classes.paper}>
          <Avatar className={classes.avatar}>
            <LockOutlinedIcon />
          </Avatar>
          <Typography component='h1' variant='h5'>
            Sign in
          </Typography>
          <form className={classes.form} onSubmit={formik.handleSubmit}>
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
              id='password'
              name='password'
              label='Password'
              value={formik.values.password}
              onChange={formik.handleChange}
              error={formik.touched.password && Boolean(formik.errors.password)}
              helperText={formik.touched.password && formik.errors.password}
            />

            <Button
              type='submit'
              fullWidth
              variant='contained'
              color='primary'
              className={classes.submit}
            >
              Sign In
            </Button>

            <Box align='center'>
              <Link to='/signup'>{"Don't have an account? Sign Up"}</Link>
            </Box>
          </form>
        </div>
        <div style={{ marginTop: 20 }}>
          <Copyright />
        </div>
      </Container>
    </div>
  )
}
