﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFixture
{
    /// <summary>
    /// Object representing a data request
    /// </summary>
    public class DataRequest
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="parentRequest">parent request</param>
        /// <param name="requestedType">new type to create</param>
        public DataRequest(DataRequest parentRequest, Type requestedType) : this(parentRequest,
                                                                                 parentRequest.Fixture,
                                                                                 requestedType,
                                                                                 parentRequest.RequestName,
                                                                                 parentRequest.Populate,
                                                                                 parentRequest.Constraints,
                                                                                 parentRequest.ExtraInfo)
        {
            
        }

        /// <summary>
        /// Date request constructor
        /// </summary>
        /// <param name="parentRequest">parent request</param>
        /// <param name="fixture">fixture this request is associated with</param>
        /// <param name="requestedType">type being requested</param>
        /// <param name="requestName">request name for this request</param>
        /// <param name="populate">populate properties</param>
        /// <param name="constraints">constraints object</param>
        /// <param name="extraInfo">extra info (PropertyInfo or ParameterInfo)</param>
        public DataRequest(DataRequest parentRequest, Fixture fixture, Type requestedType, string requestName, bool populate, object constraints, object extraInfo)
        {
            ParentRequest = parentRequest;
            Fixture = fixture;
            RequestedType = requestedType;
            RequestName = requestName ?? "";
            Populate = populate;
            Constraints = constraints;
            ExtraInfo = extraInfo;

            RequestDepth = parentRequest != null ? parentRequest.RequestDepth + 1 : 1;
        }

        /// <summary>
        /// Parent request
        /// </summary>
        public DataRequest ParentRequest { get; private set; }

        /// <summary>
        /// Fixture this request is associated with
        /// </summary>
        public Fixture Fixture { get; private set; }

        /// <summary>
        /// Request name
        /// </summary>
        public string RequestName { get; private set; }

        /// <summary>
        /// Type being requested
        /// </summary>
        public Type RequestedType { get; private set; }

        /// <summary>
        /// Populate public properties
        /// </summary>
        public bool Populate { get; private set; }

        /// <summary>
        /// Constraints object for request
        /// </summary>
        public object Constraints { get; private set; }

        /// <summary>
        /// Extra Info for request (PropertyInfo or ParameterInfo)
        /// </summary>
        public object ExtraInfo { get; private set; }

        /// <summary>
        /// Request Depth
        /// </summary>
        public int RequestDepth { get; private set; }
    }
}
