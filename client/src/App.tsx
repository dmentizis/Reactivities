import { List, ListItem, ListItemText, Typography } from "@mui/material";
import axios from "axios";
import { useEffect, useState } from "react";

function App() {
  // const title = 'Welcome to Reactivities' // Does not remember the value through the life cycle of the component.
  const [activities, setActivities] = useState<Activity[]>([]); // this hook solves the scope problem | here we declare the state's type/inteface

  //callback function inside the hook
  useEffect(() => {
    axios.get<Activity[]>("https://localhost:5001/api/activities") // returns a js promise
      .then(response => setActivities(response.data))
  }, [])

  return (
    //we can only return one tag in typescript but this tag can have more tags under it.
    //  alternatively:  <Fragment></Fragment>
    <>
      <Typography variant="h3">Reactivities</Typography>
      <List>
        {activities.map((activity) => (
          <ListItem key={activity.id}>
            <ListItemText>{activity.title}</ListItemText>
          </ListItem>
        ))}
      </List>
    </>
  )
}

export default App
