module.exports = (targetVal, opts) => {
    if (!targetVal) {
      return [
        {
          message: 'Value must defined.',
        },
      ];
    }

    if(!opts.values.some(value => targetVal[value])) {
      return [
        {
          message: `Property should contain one of the following values: ${opts.values.join(', ')}`,
        },
      ];
    }
  };