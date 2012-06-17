﻿using System;
using System.Linq.Expressions;

namespace SharpRepository.Repository.Caching
{
    /// <summary>
    /// Implements Write-Through caching for all CRUD operations (writing to the database and cache at the same time), and Generational caching for all queries (FindAll, GetAll, Find).
    /// </summary>
    /// <typeparam name="T">Type of the entity the corresponding repository queries against.</typeparam>
    public class StandardCachingStrategy<T> : StandardCachingStrategyBase<T, int, int>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StandardCachingStrategy&lt;T&gt;"/> class.
        /// </summary>
        public StandardCachingStrategy()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StandardCachingStrategy&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="cachingProvider">The caching provider to use (e.g. <see cref="InMemoryCachingProvider"/>, <see cref="MemcachedCachingProvider"/>, etc.).  Defaults to <see cref="InMemoryCachingProvider"/>.</param>
        public StandardCachingStrategy(ICachingProvider cachingProvider) 
            : base(cachingProvider)
        {
            Partition = null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StandardCachingStrategy&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="cachingProvider">The caching provider to use (e.g. <see cref="InMemoryCachingProvider"/>, <see cref="MemcachedCachingProvider"/>, etc.).  Defaults to <see cref="InMemoryCachingProvider"/>.</param>
        /// <param name="partition">The property that should be used for partitioning</param>
        public StandardCachingStrategy(ICachingProvider cachingProvider, Expression<Func<T, int>> partition)
            : base(cachingProvider)
        {
            Partition = partition;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StandardCachingStrategy&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="partition">The property that should be used for partitioning.</param>
        public StandardCachingStrategy(Expression<Func<T, int>> partition)
        {
            Partition = partition;
        }
    }

    /// <summary>
    /// Implements Write-Through caching for all CRUD operations (writing to the database and cache at the same time), and Generational caching for all queries (FindAll, GetAll, Find).
    /// </summary>
    /// <typeparam name="T">Type of the entity the corresponding repository queries against.</typeparam>
    /// <typeparam name="TKey">The primary key type of the entity</typeparam>
    public class StandardCachingStrategy<T, TKey> : StandardCachingStrategyBase<T, TKey, int>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StandardCachingStrategy&lt;T, TKey&gt;"/> class.
        /// </summary>
        public StandardCachingStrategy() : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StandardCachingStrategy&lt;T, TKey&gt;"/> class.
        /// </summary>
        /// <param name="cachingProvider">The caching provider to use (e.g. <see cref="InMemoryCachingProvider"/>, <see cref="MemcachedCachingProvider"/>, etc.).  Defaults to <see cref="InMemoryCachingProvider"/>.</param>
        public StandardCachingStrategy(ICachingProvider cachingProvider)
            : base(cachingProvider)
        {
            Partition = null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StandardCachingStrategy&lt;T, TKey&gt;"/> class.
        /// </summary>
        /// <param name="cachingProvider">The caching provider to use (e.g. <see cref="InMemoryCachingProvider"/>, <see cref="MemcachedCachingProvider"/>, etc.).  Defaults to <see cref="InMemoryCachingProvider"/>.</param>
        /// <param name="partition">The property that should be used for partitioning.</param>
        public StandardCachingStrategy(ICachingProvider cachingProvider, Expression<Func<T, int>> partition)
            : base(cachingProvider)
        {
            Partition = partition;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StandardCachingStrategy&lt;T, TKey&gt;"/> class.
        /// </summary>
        /// <param name="partition">The property that should be used for partitioning.</param>
        public StandardCachingStrategy(Expression<Func<T, int>> partition)
        {
            Partition = partition;
        }
    }

    /// <summary>
    /// Implements Write-Through caching for all CRUD operations (writing to the database and cache at the same time), and Generational caching for all queries (FindAll, GetAll, Find) with the option to partition the Generational Cache based on a specific entity property for better performance in certain situations.
    /// </summary>
    /// <typeparam name="T">Type of the entity the corresponding repository queries against.</typeparam>
    /// <typeparam name="TKey">The primary key type of the entity</typeparam>
    /// <typeparam name="TPartition">The type of the column that the Generational Cache will be partitioned on.</typeparam>
    public class StandardCachingStrategy<T, TKey, TPartition> : StandardCachingStrategyBase<T, TKey, TPartition>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StandardCachingStrategy&lt;T, TKey, TPartition&gt;"/> class.
        /// </summary>
        public StandardCachingStrategy()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StandardCachingStrategy&lt;T, TKey, TPartition&gt;"/> class.
        /// </summary>
        /// <param name="partition">The property that should be used for partitioning.</param>
        public StandardCachingStrategy(Expression<Func<T, TPartition>> partition)
        {
            Partition = partition;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StandardCachingStrategy&lt;T, TKey, TPartition&gt;"/> class.
        /// </summary>
        /// <param name="cachingProvider">The caching provider to use (e.g. <see cref="InMemoryCachingProvider"/>, <see cref="MemcachedCachingProvider"/>, etc.).  Defaults to <see cref="InMemoryCachingProvider"/>.</param>
        /// <param name="partition">The property that should be used for partitioning.</param>
        public StandardCachingStrategy(ICachingProvider cachingProvider, Expression<Func<T, TPartition>> partition)
            : base(cachingProvider)
        {
            Partition = partition;
        }
    }
}