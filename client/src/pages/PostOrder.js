import {
  Button,
  Container,
  FormControl,
  InputLabel,
  makeStyles,
  MenuItem,
  Select,
  TextField,
  Toolbar,
  Typography,
} from '@material-ui/core'
import { useFormik } from 'formik'
import { postOfferValidation } from '../helpers/yupValidation'
import NavBar from '../components/NavBar'
import { useLocation } from 'react-router-dom'
import { useState } from 'react'

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
  formControl: {
    marginTop: theme.spacing(4),
    marginBottom: theme.spacing(1),
    width: '100%',
  },
  selectEmpty: {
    marginTop: theme.spacing(2),
  },
}))

export default function PostOrder(props) {
  const classes = useStyles()
  const { pathname } = useLocation()

  const [category, setCategory] = useState(1)

  const handleChangeCatg = event => {
    setCategory(event.target.value)
  }

  const formik = useFormik({
    initialValues: {
      title: '',
      description: '',
      startDate: '',
      endDate: '',
    },
    validationSchema: postOfferValidation,
    onSubmit: values => {
      console.log(values, category)
    },
  })

  return (
    <div>
      <NavBar path={pathname} />
      <Toolbar />
      <Container component='main' maxWidth='sm'>
        <div className={classes.paper}>
          <Typography component='h5' variant='h5'>
            Post your offer
          </Typography>

          <div style={{ width: '100%' }}>
            <FormControl className={classes.formControl}>
              <InputLabel shrink id='category-select-label'>
                Category
              </InputLabel>
              <Select
                labelId='category-select-label'
                id='category-select'
                value={category}
                onChange={handleChangeCatg}
                className={classes.selectEmpty}
              >
                <MenuItem value={1}>Electronics</MenuItem>
                <MenuItem value={2}>Home Goods</MenuItem>
                <MenuItem value={3}>Education</MenuItem>
                <MenuItem value={4}>Clothing</MenuItem>
              </Select>
            </FormControl>

            <form className={classes.form} onSubmit={formik.handleSubmit}>
              <TextField
                variant='outlined'
                fullWidth
                margin='normal'
                id='title'
                name='title'
                label='Title'
                value={formik.values.title}
                onChange={formik.handleChange}
                error={formik.touched.title && Boolean(formik.errors.title)}
                helperText={formik.touched.title && formik.errors.title}
              />

              <TextField
                variant='outlined'
                fullWidth
                margin='normal'
                id='description'
                name='description'
                label='Description'
                value={formik.values.description}
                onChange={formik.handleChange}
                error={
                  formik.touched.description &&
                  Boolean(formik.errors.description)
                }
                helperText={
                  formik.touched.description && formik.errors.description
                }
              />

              <TextField
                variant='outlined'
                fullWidth
                margin='normal'
                id='startDate'
                name='startDate'
                label='Start Date'
                value={formik.values.startDate}
                onChange={formik.handleChange}
                error={
                  formik.touched.startDate && Boolean(formik.errors.startDate)
                }
                helperText={formik.touched.startDate && formik.errors.startDate}
              />

              <TextField
                variant='outlined'
                fullWidth
                margin='normal'
                id='endDate'
                name='endDate'
                label='End Date'
                value={formik.values.endDate}
                onChange={formik.handleChange}
                error={formik.touched.endDate && Boolean(formik.errors.endDate)}
                helperText={formik.touched.endDate && formik.errors.endDate}
              />

              {/* <TextField
                variant='outlined'
                fullWidth
                margin='normal'
                id='category'
                name='category'
                label='Category'
                value={formik.values.category}
                onChange={formik.handleChange}
                error={
                  formik.touched.category && Boolean(formik.errors.category)
                }
                helperText={formik.touched.category && formik.errors.category}
              /> */}

              <Button
                type='submit'
                fullWidth
                variant='contained'
                color='primary'
                className={classes.submit}
              >
                Post Offer
              </Button>
            </form>
          </div>
        </div>
      </Container>
    </div>
  )
}
