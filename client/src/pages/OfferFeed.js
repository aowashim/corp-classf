import React, { useContext } from 'react'
import NavBar from '../components/NavBar'
import Button from '@material-ui/core/Button'
import Card from '@material-ui/core/Card'
import CardActions from '@material-ui/core/CardActions'
import CardContent from '@material-ui/core/CardContent'
import Grid from '@material-ui/core/Grid'
import Typography from '@material-ui/core/Typography'
import { makeStyles } from '@material-ui/core/styles'
import Container from '@material-ui/core/Container'
import { useLocation } from 'react-router-dom'
import Link from '@material-ui/core/Link'
import { useState, useEffect } from 'react'
import { getAllOfferApi } from '../helpers/API/offer'
import Loading from '../components/Loading'
import {
  FormControl,
  InputLabel,
  Select,
  MenuItem,
  Toolbar,
  Divider,
} from '@material-ui/core'
import UserContext from '../store/UserContext'

function Copyright() {
  return (
    <Typography variant='body2' color='textSecondary' align='center'>
      {'Copyright © '}
      <Link color='inherit' href='https://mui.com/'>
        Your Website
      </Link>{' '}
      {new Date().getFullYear()}
      {'.'}
    </Typography>
  )
}

const useStyles = makeStyles(theme => ({
  icon: {
    marginRight: theme.spacing(2),
  },
  heroContent: {
    backgroundColor: theme.palette.background.paper,
    padding: theme.spacing(8, 0, 6),
  },
  heroButtons: {
    marginTop: theme.spacing(4),
  },
  cardGrid: {
    paddingTop: theme.spacing(8),
    paddingBottom: theme.spacing(8),
  },
  formControl: {
    marginTop: theme.spacing(4),
    marginBottom: theme.spacing(1),
    width: '100%',
  },
  card: {
    // boxShadow: "0px 0px 27px 0px rgba(94,94,94,0.64)",
    height: '100%',
    display: 'flex',
    flexDirection: 'column',
  },
  cardMedia: {
    paddingTop: '56.25%', // 16:9
  },
  cardContent: {
    flexGrow: 1,
  },
  footer: {
    backgroundColor: theme.palette.background.paper,
    padding: theme.spacing(6),
  },
}))

// const cards = [1, 2, 3, 4, 5, 6, 7, 8, 9];

export default function OfferFeed(props) {
  const classes = useStyles()

  const [error, setError] = useState(null)
  const [isLoaded, setIsLoaded] = useState(false)
  const [items, setItems] = useState([])
  const [viewOfferBy, setViewOfferBy] = useState(5)
  const { user } = useContext(UserContext)

  const { pathname } = useLocation()

  useEffect(() => {
    handleGetOffers()
  }, [viewOfferBy])

  const handleGetOffers = async () => {
    // const res = await getAllOfferApi()
    let res

    if (viewOfferBy === 5) {
      res = await getAllOfferApi('offer')
    } else if (viewOfferBy === 6) {
      res = await getAllOfferApi(`getOfferDetailsByEmpID/${user.id}`)
    } else if (viewOfferBy === 8) {
      res = await getAllOfferApi('getOfferByTopLikes')
    } else if (viewOfferBy === 9) {
      res = await getAllOfferApi('getOfferByPostedDate')
    } else if (
      viewOfferBy === 1 ||
      viewOfferBy === 2 ||
      viewOfferBy === 3 ||
      viewOfferBy === 4
    ) {
      res = await getAllOfferApi(`getOfferDetailsByCategory/${viewOfferBy}`)
    }

    if (res.status === 200) {
      setItems(res.data)
      setIsLoaded(true)
    } else {
      alert('An error occurred, please try again...')
    }
  }

  return (
    <>
      <NavBar path={pathname} />
      <Toolbar />
      <div>
        <Container maxWidth='md'>
          <FormControl className={classes.formControl}>
            <InputLabel shrink id='offer-select-label'>
              Filter offer
            </InputLabel>
            <Select
              labelId='offer-select-label'
              id='offer-select'
              value={viewOfferBy}
              onChange={e => setViewOfferBy(e.target.value)}
              className={classes.selectEmpty}
            >
              <MenuItem value={5}>All Offers</MenuItem>
              <MenuItem value={6}>My Offers</MenuItem>
              <Divider />

              <MenuItem value={7}>Recently Liked</MenuItem>
              <MenuItem value={8}>Top Likes</MenuItem>
              <MenuItem value={9}>Posted Date</MenuItem>
              <Divider />

              <MenuItem value={1}>Electronics</MenuItem>
              <MenuItem value={2}>Home Goods</MenuItem>
              <MenuItem value={3}>Education</MenuItem>
              <MenuItem value={4}>Clothing</MenuItem>
            </Select>
          </FormControl>
        </Container>

        <Container component='main' className={classes.cardGrid} maxWidth='md'>
          <Grid container spacing={4}>
            {items.map(item => (
              <Grid item key={item.id} xs={12} sm={6}>
                <Card className={classes.card}>
                  {/* <CardMedia
                    className={classes.cardMedia}
                    image="https://source.unsplash.com/random"
                    title="Image title"
                  /> */}
                  <CardContent className={classes.cardContent}>
                    <Typography gutterBottom variant='h5' component='h2'>
                      {item.title}
                    </Typography>
                    <Typography gutterBottom variant='h5' component='h6'>
                      {item.description}
                    </Typography>
                    <Typography>{item.empName}</Typography>
                  </CardContent>
                  <CardActions>
                    <Button size='small' color='primary'>
                      View
                    </Button>
                    <Button size='small' color='primary'>
                      Edit
                    </Button>
                  </CardActions>
                </Card>
              </Grid>
            ))}
          </Grid>
        </Container>
      </div>
      {/* Footer */}
      {/* <footer className={classes.footer}>
        <Typography variant='h6' align='center' gutterBottom>
          Footer
        </Typography>
        <Typography
          variant='subtitle1'
          align='center'
          color='textSecondary'
          component='p'
        >
          Something here to give the footer a purpose!
        </Typography>
        <Copyright />
      </footer> */}
      {/* End footer */}
    </>
  )
}
