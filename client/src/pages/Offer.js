import React from "react";
import NavBar from "../components/NavBar";
import CssBaseline from "@material-ui/core/CssBaseline";
import Typography from "@material-ui/core/Typography";
import { makeStyles } from "@material-ui/core/styles";
import Container from "@material-ui/core/Container";
import { useLocation } from "react-router-dom";
import Link from "@material-ui/core/Link";
import { Button } from "@material-ui/core";
import Icon from "@material-ui/core/Icon";
import FavoriteIcon from "@mui/icons-material/Favorite";
import CalendarMonthIcon from "@mui/icons-material/CalendarMonth";
import Comment from "../components/Comment";
import Divider from "@material-ui/core/Divider";
import WriteComment from "../components/WriteComment";

function Copyright() {
  return (
    <Typography variant="body2" color="textSecondary" align="center">
      {"Copyright © "}
      <Link color="inherit" href="https://mui.com/">
        Your Website
      </Link>{" "}
      {new Date().getFullYear()}
      {"."}
    </Typography>
  );
}

const useStyles = makeStyles((theme) => ({
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
  cont_each: {
    padding: "1rem",
  },
  bnn: {
    display: "flex",
    justifyContent: "space-between",
  },
  cmtsec:{
    marginTop:"2rem",
  },
  card: {
    height: "100%",
    boxShadow: "0px 0px 10px 0px rgba(94,94,94,0.64)",
    display: "flex",
    border: "1rem",
    padding: "5rem",
    borderRadius: "10px",
    flexDirection: "column",
  },
}));

const cards = [1, 2, 3, 4, 5, 6, 7, 8, 9];

export default function OfferFeed() {
  const classes = useStyles();

  const { pathname } = useLocation();
  return (
    <React.Fragment>
      <CssBaseline />
      <NavBar path={pathname} />
      <main>
        <div className={classes.heroContent}>
          <Container maxWidth="md"></Container>
        </div>

        <Container className={classes.card} maxWidth="md">
          <Container className={classes.cont_each} maxWidth="md">
            <Typography variant="h4" align="left">
              Employee Name
            </Typography>
            <Typography variant="h6" align="left">
              12 April at 9:28 pm
            </Typography>
          </Container>
          <Container maxWidth="md">
            <Typography variant="h2" align="center">
              Lorem ipsum dolor sit
            </Typography>
            <Typography
              className={classes.cont_each}
              variant="subtitle1"
              align="justify"
            >
              Lorem ipsum dolor sit amet consectetur, adipisicing elit. Dolores
              itaque magni non aut amet eum adipisci sunt numquam perspiciatis
              molestias necessitatibus sapiente doloribus sed deserunt quibusdam
              at, nam, sit aliquid!
            </Typography>
          </Container>
          <Container className={classes.bnn} maxWidth="md">
            <Button size="large" color="primary">
              <FavoriteIcon></FavoriteIcon>
              Like
            </Button>
            <Button size="large" color="primary">
              <CalendarMonthIcon></CalendarMonthIcon>
              Engage
            </Button>
          </Container>
          <Container className={classes.cmtsec}>
            <WriteComment></WriteComment>
            
          </Container>
          <Divider variant="fullWidth" style={{ margin: "30px 0" }} />
          <Container>
              <Typography variant="h5" align="left">
                Comments
              </Typography>
            <Comment></Comment>
            <Comment></Comment>
          </Container>
        </Container>
      </main>
    </React.Fragment>
  );
}
