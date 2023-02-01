using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Nearest_Vehicles_to_points.Classes
{
    /// <summary>
    /// Data Process
    /// </summary>
    public class DataProcess
    {
        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public DataProcess()
        {
            Positions = new List<Position>();
        }

        #endregion Constructors

        #region Private Variables

        /// <summary>
        /// Closest Position
        /// </summary>
        private Position closestPosition = null;

        /// <summary>
        /// Distance
        /// </summary>
        private Nullable<double> distance = 0;

        #endregion Private Variables

        #region Public Properties

        /// <summary>
        /// Positions List
        /// </summary>
        public List<Position> Positions { get; }

        /// <summary>
        /// Closest Position
        /// </summary>
        public Position ClosestPosition => this.closestPosition;

        /// <summary>
        /// Distance
        /// </summary>
        public Nullable<double> Distance => this.distance;

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Load Data
        /// </summary>
        public void LoadData()
        {
            this.Positions.Clear();
            int counter = 0;
            using (FileStream fs = File.OpenRead("VehiclePositions.dat"))
            using (BinaryReader reader = new BinaryReader(fs))
                try
                {
                    while (reader.BaseStream.Position < reader.BaseStream.Length)
                    {
                        counter++;
                        int positionID = reader.ReadInt32();
                        string vehicleRegistration = reader.ReadString();
                        float latitude = reader.ReadSingle();
                        float longitude = reader.ReadSingle();
                        ulong recordedTimeUTC = reader.ReadUInt64();
                        this.Positions.Add(new Position()
                        {
                            PositionID = positionID,
                            VehicleRegistration = vehicleRegistration,
                            Latitude = latitude,
                            Longitute = longitude
                        });
                    }
                }
                catch (Exception ex)
                {
                    // Error trapping to be added
                }
            Debug.WriteLine("Loaded {counter} records");
        }

        /// <summary>
        /// Get Closest
        /// </summary>
        /// <param name="LatitudeParameter">Latitude</param>
        /// <param name="LongitudeParameter">Longitude</param>
        /// <returns></returns>
        public void GetClosest(float LatitudeParameter, float LongitudeParameter)
        {
            this.closestPosition = null;
            foreach(Position position in this.Positions)
            {
                double calcDistance = Math.Sqrt(Math.Pow(position.Latitude - LatitudeParameter, 2)
                    + Math.Pow(position.Longitute - LongitudeParameter, 2));

                if (!this.distance.HasValue || (calcDistance < this.distance))
                {
                    this.distance = calcDistance;
                    this.closestPosition = position;
                }
            }
        }

        #endregion Public Methods
    }
}
