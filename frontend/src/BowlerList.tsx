// This component will display a list of bowlers in a table
import { useEffect, useState } from 'react';
import { bowler } from './types/bowler';
import './styles.css';

function BowlerList() {
  // Create a state variable to hold the bowlers
  // Initialize the state variable to an empty array
  const [bowlers, setBowlers] = useState<bowler[]>([]);

  // Fetch the bowlers from the server
  useEffect(() => {
    const fetchBowler = async () => {
      const response = await fetch('https://localhost:5001/bowling');
      const data = await response.json();
      setBowlers(data);
    };
    fetchBowler();
  }, []);

  // Display the bowlers in a table
  return (
    <>
      <h1>Bowler List</h1>
      <table>
        <thead>
          <th>Bowler Name</th>
          <th>Team Name</th>
          <th>Address</th>
          <th>City</th>
          <th>State</th>
          <th>Zip</th>
          <th>Phone Number</th>
        </thead>
        <tbody>
          {bowlers.map((b) => (
            <tr key={b.bowlerId}>
              <td>
                {b.bowlerFirstName} {b.bowlerMiddleInit} {b.bowlerLastName}
              </td>
              <td>{b.teamName}</td>
              <td>{b.bowlerAddress}</td>
              <td>{b.bowlerCity}</td>
              <td>{b.bowlerState}</td>
              <td>{b.bowlerZip}</td>
              <td>{b.bowlerPhoneNumber}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </>
  );
}

export default BowlerList;
