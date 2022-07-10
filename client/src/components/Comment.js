import React from 'react'
import Typography from '@material-ui/core/Typography'
import { makeStyles } from '@material-ui/core/styles'
import Container from '@material-ui/core/Container'
import Link from '@material-ui/core/Link'
import Grid from '@material-ui/core/Grid'
import Divider from '@material-ui/core/Divider'

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
  ppr: {
    padding: '2rem',
    margin: '1rem',
    border: 'none',
  },
  card: {
    height: '100%',
    padding: '0',
    marginTop: '2rem',
  },
}))

export default function Comment() {
  const classes = useStyles()

  return (
    <div>
      {/* <Container className={classes.ppr}> */}
      <Grid container wrap='nowrap' spacing={2}>
        {/* <Grid item>
                <Avatar alt="Remy Sharp" src={imgLink} />
              </Grid> */}
        <Grid justifyContent='left' item xs zeroMinWidth>
          <h4 style={{ margin: 0, textAlign: 'left' }}>Michel Michel</h4>
          <p style={{ textAlign: 'left' }}>
            Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean
            luctus ut est sed faucibus. Duis bibendum ac ex vehicula laoreet.
            Suspendisse congue vulputate lobortis. Pellentesque at interdum
            tortor.
          </p>
          <p style={{ textAlign: 'left', color: 'gray' }}>
            posted 1 minute ago
          </p>
        </Grid>
      </Grid>
      {/* </Container> */}
      <Divider variant='fullWidth' style={{ margin: '30px 0' }} />
    </div>
  )
}
