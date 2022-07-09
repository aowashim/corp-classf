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
import { useState, useEffect } from "react";

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
  cmtsec: {
    marginTop: "2rem",
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

  const [error, setError] = useState(null);
  const [isLoaded, setIsLoaded] = useState(false);
  const [items, setItems] = useState([]);

  useEffect(() => {
    fetch("http://localhost:19759/api/getOfferDetails/15")
      .then((res) => res.json())
      .then(
        (result) => {
          setIsLoaded(true);
          setItems(result);
        },
        // Note: it's important to handle errors here
        // instead of a catch() block so that we don't swallow
        // exceptions from actual bugs in components.
        (error) => {
          setIsLoaded(true);
          setError(error);
        }
      );
  }, []);

  const { pathname } = useLocation();
  if (error) {
    return (
      <div>
        <h3>Error Error</h3>
        Error: {error.message}
      </div>
    );
  } else if (!isLoaded) {
    return <div>Loading...</div>;
  } else {
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
                {items.emp_Id}
              </Typography>
              <Typography variant="h6" align="left">
                {items.start_Date}
              </Typography>
            </Container>
            <Container maxWidth="md">
              <Typography variant="h2" align="center">
                {items.title}
              </Typography>
              <Typography
                className={classes.cont_each}
                variant="subtitle1"
                align="justify"
              >
                {items.description}
              </Typography>
            </Container>
            <Container className={classes.bnn} maxWidth="md">
              <Button size="large" color="primary">
                <FavoriteIcon></FavoriteIcon>
                {items.n_Likes} Like
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
              {/* {
                items.commentList.forEach(cmt => {
                  <comment></comment>
                })
              } */}
            </Container>
          </Container>
        </main>
      </React.Fragment>
    );
  }
}
